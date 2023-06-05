using Battle.Units;
using Battle.Units.Enemies;
using UnityEngine;

namespace Battle
{
    public abstract class Spell : SerializedUseAble
    {
        [SerializeField] protected int manaCost;

        [SerializeField] public string title;

        public abstract void Cast();

        protected bool CantCast()
        {
            bool stateCheck = unitRelated switch
            {
                Player => BattleManager.State != BattleState.Turn,
                Enemy => BattleManager.State != BattleState.EnemiesAct,
                _ => false
            };
            if (stateCheck || unitRelated.mana < manaCost) return true;
            unitRelated.mana -= manaCost;
            return false;
        }

        public override void Use()
        {
            // ReSharper disable once Unity.NoNullPropagation
            useAble?.Use();
        }
    }
}