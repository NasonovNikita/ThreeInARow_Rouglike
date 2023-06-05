using UnityEngine;

namespace Battle.Conditions
{
    
    [CreateAssetMenu(fileName = "DmgCond", menuName = "Conditions/EqualDamage")]
    public class DamageCondition : Condition
    {
        [SerializeField] private int damage;
        private DamageLog _log;
        
        protected override void LogUpdate(Log log)
        {
            if (log is DamageLog neededLog) LogUpdate(neededLog);
        }

        private void LogUpdate(DamageLog log)
        {
            _log = log;
            if (Check()) Use();
        }

        private bool Check()
        {
            var data = _log?.Data();
            return data?.Item3 == damage;
        }

        public override void Use()
        {
            // ReSharper disable once Unity.NoNullPropagation
            useAble?.Use();
        }
    }
}