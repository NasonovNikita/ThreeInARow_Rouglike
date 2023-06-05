using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "PoweredKick", menuName = "Spells/PoweredKick")]
    public class PoweredKick : Spell
    {
        [SerializeField] private int stunMoves;
        public override void Cast()
        {
            if (CantCast()) return;
        
            BattleManager.player.mana -= manaCost;
            Modifier.CreateModifier(unitRelated, stunMoves, ModType.Stun);
            // ReSharper disable once Unity.NoNullPropagation
            useAble?.Use();
            BattleManager.EndTurn();
        }
    }
}