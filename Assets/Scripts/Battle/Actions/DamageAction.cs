using UnityEngine;

namespace Battle.Actions
{
    [CreateAssetMenu(fileName = "NDmg", menuName = "Actions/Dmg")]
    public class DamageAction : SerializedUseAble
    {
        public override void Use()
        {
            unitRelated.DoDamage((int) value);
        }
    }
}