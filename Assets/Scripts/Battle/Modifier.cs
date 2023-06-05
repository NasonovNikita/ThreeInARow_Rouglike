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
        
        [SerializeField] public int moves;

        public float GetValue() => moves != 0 ? value : 0;


        public static void CreateModifier(Unit unit, int moves, ModType type, ModAffect affects = ModAffect.None,
            StatType statType = StatType.None, float value = 1)
        {
            Modifier mod = CreateInstance<Modifier>();
            mod.Init(moves, type, affects, statType, value);
            mod.Init(unit);
            mod.Use();
        }

        private void Init(int moves, ModType type, ModAffect affects = ModAffect.None,
            StatType statType = StatType.None, float value = 1)
        {
            this.moves = moves;
            this.type = type;
            this.affects = affects;
            statTypeType = statType;
            this.value = value;
            Log.logger += Move;
        }

        public override void Use()
        {
            if (moves == 0) return;

            if (type == ModType.Stun)
            {
                unitRelated.statusModifiers.Add(Instantiate(this));
            }
            else
            {
                Stat stat = statTypeType switch
                {
                    StatType.Hp => unitRelated.hp,
                    StatType.Mana => unitRelated.mana,
                    StatType.Damage => unitRelated.damage,
                    StatType.None => throw new ArgumentException("The modifier shouldn't have stat type!"),
                    _ => throw new ArgumentOutOfRangeException()
                };

                stat.AddMod(Instantiate(this), affects);
            }
        }

        private void Move(Log log)
        {
            if (log is TurnLog && moves != 0) moves -= 1;
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