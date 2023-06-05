using Battle.Units;
using JetBrains.Annotations;
using UnityEngine;

namespace Battle
{
    public abstract class SerializedUseAble : ScriptableObject
    {
        [CanBeNull]
        [SerializeField] protected SerializedUseAble useAble;
        
        public float value;

        protected Unit unitRelated;
        public abstract void Use();

        public virtual void Init(Unit unit)
        {
            unitRelated = unit;
            if (!useAble) return;
            useAble.Init(unit);
            useAble = Instantiate(useAble);
        }
    }
}