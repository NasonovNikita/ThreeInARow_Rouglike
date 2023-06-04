using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "Kick", menuName = "Spells/Kick")]
    public class Kick : Spell
    {
        public override void Cast()
        {
            if (CantCast()) return;
            
            DamageLog.Log(BattleManager.player, BattleManager.target, (int) useAble.value);
            useAble.Use();
        }
    }
}