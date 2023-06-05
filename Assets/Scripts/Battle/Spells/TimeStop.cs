using System.Diagnostics.CodeAnalysis;
using Battle.Units;
using Battle.Units.Enemies;
using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "TimeStop", menuName = "Spells/TimeStop")]
    public class TimeStop : Spell
    {
        [SuppressMessage("ReSharper", "Unity.NoNullPropagation")]
        public override void Cast()
        {
            if (CantCast()) return;
        
            BattleManager.player.mana -= manaCost;

            switch (unitRelated)
            {
                case Player:
                {
                    foreach (Enemy enemy in BattleManager.enemies)
                    {
                        useAble?.Init(enemy);
                        useAble?.Use();
                        
                    }
                    break;
                }
                case Enemy:
                    useAble?.Init(BattleManager.player);
                    useAble?.Use();
                    break;
            }
        }
    }
}