using System;
using Battle.Units;
using UnityEngine;

namespace Battle.Conditions
{
    [CreateAssetMenu(fileName = "CheckStat", menuName = "Conditions/CheckStat")]
    public class CheckStatCondition : Condition
    {
        [SerializeField] private StatType type;

        [SerializeField] private CompareMethod compare;

        public override void Use()
        {
            Stat stat = type switch
            {
                StatType.Hp => unitRelated.hp,
                StatType.Mana => unitRelated.mana,
                StatType.Damage => unitRelated.damage,
                StatType.None => throw new ArgumentException(),
                _ => throw new ArgumentOutOfRangeException()
            };
            // ReSharper disable once Unity.NoNullPropagation
            if (Compare((int) stat, (int) value)) useAble?.Use();
        }

        protected override void LogUpdate(Log log) {}

        private bool Compare(int a, int b)
        {
            return compare switch
            {
                CompareMethod.Bigger => a > b,
                CompareMethod.AtLeast => a >= b,
                CompareMethod.Equals => a == b,
                CompareMethod.NotMore => a <= b,
                CompareMethod.Less => a < b,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public enum CompareMethod
    {
        Bigger,
        AtLeast,
        Equals,
        NotMore,
        Less
    }
}