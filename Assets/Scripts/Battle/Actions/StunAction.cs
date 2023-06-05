using UnityEngine;

namespace Battle.Actions
{
    [CreateAssetMenu(fileName = "StunAction", menuName = "Actions/StunAction")]
    public class StunAction : SerializedUseAble
    {
        public override void Use()
        {
            // ReSharper disable once Unity.NoNullPropagation
            useAble?.Use();
        }
    }
}