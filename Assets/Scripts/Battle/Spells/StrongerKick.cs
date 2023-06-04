using Battle.Units;
using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "StrongerKick", menuName = "Spells/StrongerKick")]
    public class StrongerKick : Spell
    {
        [SerializeField] private int moves;

        [SerializeField] private float value;
        public override void Cast()
        {
            if (CantCast()) return;
        
            BattleManager.player.mana -= manaCost;
            Modifier.CreateModifier(BattleManager.player, moves, ModType.Mul, ModAffect.Get, StatType.Damage, value);
        }
    }
}