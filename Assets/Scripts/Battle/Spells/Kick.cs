using System.Diagnostics.CodeAnalysis;
using Battle.Units;
using Battle.Units.Enemies;
using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "Kick", menuName = "Spells/Kick")]
    public class Kick : Spell
    {
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        [SuppressMessage("ReSharper", "Unity.NoNullPropagation")]
        public override void Cast()
        {
            if (CantCast()) return;
            switch (unitRelated)
            {
                case Player:
                    DamageLog.Log(BattleManager.player, BattleManager.target, (int) useAble?.value);
                    useAble.Init(BattleManager.target);
                    useAble.Use();
                    break;
                case Enemy:
                    DamageLog.Log(BattleManager.target, BattleManager.player, (int) useAble?.value);
                    useAble.Init(BattleManager.player);
                    useAble.Use();
                    break;
            }
            
        }
    }
}