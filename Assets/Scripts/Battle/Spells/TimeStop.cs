using Battle.Units;
using Battle.Units.Enemies;
using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "TimeStop", menuName = "Spells/TimeStop")]
    public class TimeStop : Spell
    {
        [SerializeField] private int moves;
        
        public override void Cast()
        {
            if (CantCast()) return;
        
            BattleManager.player.mana -= manaCost;
        
            foreach (Enemy enemy in BattleManager.enemies)
            {
                // ReSharper disable once Unity.IncorrectScriptableObjectInstantiation
                Modifier.CreateModifier(enemy, moves, ModType.Stun);
            }
        }
    }
}