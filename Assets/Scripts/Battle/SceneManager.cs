using System;
using System.Collections.Generic;
using Audio;
using Battle.Units;
using Core.Saves;
using UI;
using UI.Battle;
using UI.MessageWindows;
using UnityEngine;

namespace Battle
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance { get; private set; }
        
        public static EnemyGroup enemyGroup;

        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private EnemyPlacer placer;
        
        [SerializeField] private BattleLose loseMessage;
        [SerializeField] private BattleWin winMessage;

        private readonly List<Enemy> enemiesWithNulls = new();

        public static event Action OnSceneFullyLoaded;
        public static event Action OnSceneLeave;
        
        public void Awake()
        {
            Instance = this;
            
            GameSave.Save();
            
            InitEnemies();
        }

        public void Start()
        {
            AudioManager.Instance.StopAll();
            AudioManager.Instance.Play(AudioEnum.Battle);
            
            TurnLabel.Instance.SetPlayerTurn();

            BattleFlowManager.Instance.enemiesWithNulls = enemiesWithNulls;
            BattleFlowManager.Instance.TurnOn();
            PickerManager.Instance.PickNextPossible();

            BattleFlowManager.Instance.OnBattleWin += WinBattle;
            BattleFlowManager.Instance.OnBattleLose += LoseBattle;
            BattleFlowManager.Instance.OnEnemiesShuffle += PlaceEnemies;
            BattleFlowManager.Instance.OnEnemiesTurnStart += TurnLabel.Instance.SetEnemyTurn;
            BattleFlowManager.Instance.OnPlayerTurnStart += TurnLabel.Instance.SetPlayerTurn;
            
            OnSceneFullyLoaded?.Invoke();
        }

        public void OnDestroy() => OnSceneLeave?.Invoke();

        private void InitEnemies()
        {
            foreach (Enemy enemy in enemyGroup.Enemies)
            {
                if (enemy == null)
                {
                    enemiesWithNulls.Add(null);
                    continue;
                }
                enemiesWithNulls.Add(LoadEnemy(enemy));
            }
            
            PlaceEnemies();
        }

        private Enemy LoadEnemy(Enemy enemy) => 
            Instantiate(enemy, mainCanvas.transform, false);
        
        private void PlaceEnemies() => placer.Place(enemiesWithNulls);

        private void LoseBattle() => Instantiate(loseMessage, UICanvas.Instance.transform);

        private void WinBattle() => 
            winMessage.Create(enemyGroup.Reward, UICanvas.Instance.transform);
    }
}