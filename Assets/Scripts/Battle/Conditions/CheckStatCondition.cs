using System;
using Battle.Units;
using UnityEngine;

namespace Battle.Conditions
{
    [CreateAssetMenu(fileName = "CheckStat", menuName = "Conditions/CheckStat")]
    public class CheckStatCondition : Condition
    {
        private Unit _unit;

        [SerializeField] private StatType type;

        [SerializeField] private CompareMethod compare;

        public override void Use()
        {
            _unit ??= BattleManager.player;

            Stat stat = type switch
            {
                StatType.Hp => _unit.hp,
                StatType.Mana => _unit.mana,
                StatType.Damage => _unit.damage,
                StatType.None => throw new ArgumentException(),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (Compare((int) stat, (int) value)) useAble.Use();
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