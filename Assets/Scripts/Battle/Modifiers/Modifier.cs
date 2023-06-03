using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class Modifier
{
    public static List<Modifier> mods = new();

    public int moves;

    public ModType type;
    
    public float value;

    public Modifier(int moves, ModType type, List<Condition> conditions, float value = 1)
    {
        this.moves = moves;
        this.type = type;
        this.value = value;
        mods.Add(this);
    }

    public float Use() => value;
    public static void Move()
    {
        foreach (Modifier mod in mods.ToList())
        {
            mod.moves -= 1;
            if (mod.moves != 0) continue;
            mods.Remove(mod);
        }
    }
}