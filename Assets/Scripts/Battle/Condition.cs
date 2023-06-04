using UnityEngine;

namespace Battle
{
    public abstract class Condition : SerializedUseAble
    {
        [SerializeField]
        protected SerializedUseAble useAble;
        
        public static void Clear()
        {
            Log.logger = null;
        }

        protected abstract void LogUpdate(Log log);

        public void Init()
        {
            Log.logger += LogUpdate;
        }
    }
}