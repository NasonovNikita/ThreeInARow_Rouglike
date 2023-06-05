using System;
using Battle.Units;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item")]
    [Serializable]
    public class Item : SerializedUseAble
    {
        [SerializeField] public string title;
        [SerializeField] private Condition cond;

        public override void Use()
        {
            cond.Use();
        }

        public override void Init(Unit unit)
        {
            cond.Init(unit);
        }
    }
}