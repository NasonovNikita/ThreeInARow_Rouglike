using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
[Serializable]
public class Item : ScriptableObject
{
    [SerializeField] private ModAffect affects;
    [SerializeField] private Modifier mod;
    [SerializeField] public string title;
    
    public void Use(Unit unitBelong)
    {
        
    }
}