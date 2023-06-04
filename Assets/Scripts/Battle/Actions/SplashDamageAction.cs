using UnityEngine;

namespace Battle.Actions
{
    [CreateAssetMenu(fileName = "SplashDmg", menuName = "Actions/SplashDmg")]
    public class SplashDamageAction : SerializedUseAble
    {
        [SerializeField] private int width;
        public override void Use()
        {
            for (int i = 0; i < width + 1 && i < BattleManager.enemies.Count; i++)
            {
                BattleManager.enemies[i].DoDamage((int) value);
            }
        }
    }
}