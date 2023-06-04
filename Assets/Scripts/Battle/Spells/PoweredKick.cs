using Battle.Units;
using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "PoweredKick", menuName = "Spells/PoweredKick")]
    public class PoweredKick : Spell
    {
        [SerializeField] private int stunMoves;

        [SerializeField] private int moves;

        [SerializeField] private float value;
        public override void Cast()
        {
            if (CantCast()) return;
        
            BattleManager.player.mana -= manaCost;
            Modifier.CreateModifier(BattleManager.player, stunMoves, ModType.Stun);
            Modifier.CreateModifier(BattleManager.player, moves, ModType.Mul, ModAffect.Get, StatType.Damage, value);
            BattleManager.EndTurn();
        }
    }
}