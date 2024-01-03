using Battle.Units;
using UI;
using UnityEngine;

namespace Battle.Items
{
    [CreateAssetMenu(fileName = "LongBraid", menuName = "Items/LongBraid")]
    public class LongBraid : Item
    {
        public override void Use(Unit unitBelong)
        {
            BattleTargetPicker.SetAllRawsAvailable();
        }
    }
}