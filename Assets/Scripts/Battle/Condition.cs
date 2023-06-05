using System.Diagnostics.CodeAnalysis;
using Battle.Units;

namespace Battle
{
    [SuppressMessage("ReSharper", "Unity.NoNullPropagation")]
    public abstract class Condition : SerializedUseAble
    {
        public static void Clear()
        {
            Log.logger = null;
        }

        protected abstract void LogUpdate(Log log);

        public override void Init(Unit unit)
        {
            unitRelated = unit;
            useAble?.Init(unit);
            Log.logger += LogUpdate;
        }

        public override void Use()
        {
            useAble?.Use();
        }
    }
}