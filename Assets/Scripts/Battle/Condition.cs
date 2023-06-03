using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Condition
{
    private static List<Condition> _conditions;

    [SerializeField] private CondActionType actionType;
    
}



internal enum CondActionType
{
    ModAdder,
    ActionExecuter
}