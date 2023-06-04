using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Audio;
using Battle.Units;
using Battle.Units.Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Grid = Battle.Match3.Grid;

namespace Battle
{
    public class BattleManager : MonoBehaviour
    {
        public static Player player;
    
        public static Grid grid;
    
        private EnemyPlacement _placer;
    
        private Canvas _canvas;

        private const float FightTime = 0.2f;

        public static EnemyGroup group;

        public static MyList<Log> Logs { get; } = new();

        public static Enemy target;
    
        public static BattleState State { get; private set; }

        public static List<Enemy> enemies;

        private Coroutine _battle;

        private bool _playerActs;
        private bool _enemiesAct;
    
        private bool _dead;
    
        public void Awake()
        {
            AudioManager.instance.StopAll();
        
            _canvas = FindFirstObjectByType<Canvas>();
            player = FindFirstObjectByType<Player>();
            grid = FindFirstObjectByType<Grid>();
            _placer = FindFirstObjectByType<EnemyPlacement>();

            player.Load();
            player.TurnOn();

            LoadSpells();

            enemies = group.GetEnemies();

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i] = LoadEnemy(i);
            }

            _placer.enemiesToPlace = enemies;
        
            _placer.Place();
        
            target = enemies[0];

            AudioManager.instance.Play(AudioEnum.Battle);
        
            GameManager.instance.SaveData();
        
            State = BattleState.Turn;
        }
    
        public static void EndTurn()
        {
            CoroutinesContainer.instance.Coroutine(PlayerAct());
        }

        public static IEnumerator KillEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        
            if (enemies.Count == 0)
            {
                State = BattleState.End;
                yield return new WaitForSeconds(FightTime);
                enemy.Delete();
                Win();
                yield break;
            }

            target = enemies[0];

            yield return new WaitForSeconds(FightTime);
        
            enemy.Delete();
        }

        public IEnumerator Die()
        {
            State = BattleState.End;
        
            yield return new WaitForSeconds(FightTime);
            player.Delete();
        
            Lose();
        }

        private static IEnumerator<WaitForSeconds> PlayerAct()
        {
            if (!player.Stunned())
            {
                State = BattleState.PlayerAct;

                player.Act();
                yield return new WaitForSeconds(FightTime);
            }

            CoroutinesContainer.instance.Coroutine(EnemiesAct());
        }

        private static IEnumerator<WaitForSeconds> EnemiesAct()
        {
            State = BattleState.EnemiesAct;

            foreach (var enemy in enemies.Where(enemy => !enemy.Stunned()))
            {
                enemy.Act();
                yield return new WaitForSeconds(FightTime);
                if (player.hp <= 0) yield break;
            }
            
            TurnLog.Log();

            if (!player.Stunned())
            {
                State = BattleState.Turn;
                grid.destroyed.Clear();
                grid.Unlock();
            }
            else
            {
                CoroutinesContainer.instance.Coroutine(EnemiesAct());
            }
        }

        private static void Win()
        {
            EndGame();
            Player.data.money += group.reward;
            SceneManager.LoadScene("Map");
        }
    
    
        // ReSharper disable Unity.PerformanceAnalysis
        private void Lose()
        {
            EndGame();
        
            GameObject menu = Instantiate(PrefabsContainer.instance.loseMessage, _canvas.transform, false);
            var buttons = menu.GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(GameManager.instance.NewGame);
            buttons[1].onClick.AddListener(GameManager.instance.MainMenu);
            menu.gameObject.SetActive(true);
        }

        private static void EndGame()
        {
            State = BattleState.End;
            grid.Block();
            foreach (var log in Logs)
            {
                Debug.unityLogger.Log(JsonUtility.ToJson(log));
            }
            Logs.Clear();
            Condition.Clear();
        }

        private Enemy LoadEnemy(int i)
        {
            Enemy enemy = Instantiate(enemies[i], _canvas.transform, false);
            enemy.TurnOn();
            return enemy;
        }

        private static void LoadSpells()
        {
            var spells = GameObject.Find("Spells");
            var spellButtons = spells.GetComponentsInChildren<Button>();
            for (int i = 0; i < player.spells.Count && i < 4; i++)
            {
                Button btn = spellButtons[i];
                Spell spell = player.spells[i];
                btn.onClick.AddListener(spell.Cast);
                TMP_Text text = btn.GetComponentInChildren<TMP_Text>();
                text.text = spell.title;
            }
        }
    }
}