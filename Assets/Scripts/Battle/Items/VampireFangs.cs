using System;
using Battle.BattleEventHandlers;
using Battle.Units;
using UnityEngine;

namespace Battle.Items
{
    [CreateAssetMenu(fileName = "VampireFangs", menuName = "Items/VampireFangs")]
    public class VampireFangs : Item
    {
        [SerializeField] private int from;
        [SerializeField] private int to;
        [SerializeField] private int minHeal;
        public override void Use(Unit unitBelong)
        {
            new EnemyGettingHitThen(() =>
            {
                int damage = ((GotDamageLog)BattleLog.GetLastLog()).GetData.Item2;
                if (damage >= from)
                {
                    unitBelong.Hp.Heal(Math.Max(minHeal, to - damage));
                }
            });
        }
    }
}