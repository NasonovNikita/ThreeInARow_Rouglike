using UnityEngine;

namespace Battle
{
    public abstract class Spell : ScriptableObject
    {
        [SerializeField] protected SerializedUseAble useAble;
        
        [SerializeField] protected int manaCost;

        [SerializeField] public string title;

        public abstract void Cast();

        protected bool CantCast()
        {
            if (BattleManager.State == BattleState.Turn && BattleManager.player.mana >= manaCost) return true;
            BattleManager.player.mana -= manaCost;
            return false;
        }
    }
}