using System;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item")]
    [Serializable]
    public class Item : ScriptableObject
    {
        [SerializeField] public string title;
        [SerializeField] private Condition cond;
    
        public void Init()
        {
            cond.Init();
        }
    }
}