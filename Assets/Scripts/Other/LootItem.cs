using System;
using Knot.Localization;
using UnityEngine;

namespace Other
{
    [Serializable]
    public abstract class LootItem : ScriptableObject
    {
        [SerializeField] protected Rarity rarity;
        public Sprite img;
        
        public int Frequency =>
            rarity switch
            {
                Rarity.Common => 20,
                Rarity.Rare => 14,
                Rarity.Epic => 9,
                Rarity.Legendary => 5,
                Rarity.Secret => 0,
                _ => throw new ArgumentOutOfRangeException()
            };

        [SerializeField] protected KnotTextKeyReference titleKeyRef;
        [SerializeField] protected KnotTextKeyReference descriptionKeyRef;

        public virtual string Title => titleKeyRef.Value;
        public virtual string Description => descriptionKeyRef.Value;

        public abstract void Get();
    }

    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Secret
    }
}