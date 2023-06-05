using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "StrongerKick", menuName = "Spells/StrongerKick")]
    public class StrongerKick : Spell
    {
        public override void Cast()
        {
            if (CantCast()) return;
        
            BattleManager.player.mana -= manaCost;
            // ReSharper disable once Unity.NoNullPropagation
            useAble?.Use();
        }
    }
}