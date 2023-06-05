using UnityEngine;

namespace Battle.Conditions
{
    [CreateAssetMenu(fileName = "EveryTurn", menuName = "Conditions/ByTurn")]
    public class EveryTurnCondition : Condition
    {
        protected override void LogUpdate(Log log)
        {
            if (log is TurnLog) Use();
        }

        public override void Use()
        {
            // ReSharper disable once Unity.NoNullPropagation
            useAble?.Use();
        }
    }
}