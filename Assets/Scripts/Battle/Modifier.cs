using System;
using System.Diagnostics.CodeAnalysis;
using Battle.Units;
using UnityEngine;

namespace Battle
{
    [SuppressMessage("ReSharper", "ParameterHidesMember")]
    [CreateAssetMenu(fileName = "Mod", menuName = "Mod")]
    public class Modifier : SerializedUseAble
    {
        [SerializeField] private ModType type;
        public ModType Type => type;
        
        [SerializeField] private ModAffect affects;
        
        [SerializeField] private StatType statTypeType;
        
        private Unit _unit;
        
        private int _moves;
        
        public float Value => value;
        
        
        public static void CreateModifier(Unit unit, int moves, ModType type, ModAffect affects = ModAffect.None,
            StatType statType = StatType.None, float value = 1)
        {
            Modifier mod = CreateInstance<Modifier>();
            mod.Init(unit, moves, type, affects, statType, value);
            mod.Use();
        }

        private void Init(Unit unit, int moves, ModType type, ModAffect affects = ModAffect.None,
            StatType statType = StatType.None, float value = 1)
        {
            _unit = unit;
            _moves = moves;
            this.type = type;
            this.affects = affects;
            statTypeType = statType;
            this.value = value;
            Log.logger += Move;
        }

        public override void Use()
        {
            if (_moves == 0) return;
            
            _unit ??= BattleManager.player;

            if (type == ModType.Stun)
            {
                _unit.statusModifiers.Add(this);
            }
            else
            {
                Stat stat = statTypeType switch
                {
                    StatType.Hp => _unit.hp,
                    StatType.Mana => _unit.mana,
                    StatType.Damage => _unit.damage,
                    StatType.None => throw new ArgumentException("The modifier shouldn't have stat type!"),
                    _ => throw new ArgumentOutOfRangeException()
                };

                stat.AddMod(this, affects);
            }
        }

        private void Move(Log log)
        {
            if (log is TurnLog) _moves -= 1;
        }
    }
    
    public enum ModAffect
    {
        Add,
        Sub,
        Get,
        None
    }
    
    public enum ModType
    {
        Add,
        Mul,
        Stun
    }
}