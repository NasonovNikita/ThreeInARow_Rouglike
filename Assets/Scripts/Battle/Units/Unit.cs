using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.Units
{
    public abstract class Unit : MonoBehaviour
    {
        public Stat hp;
        public Stat mana;
        public Stat damage;

        public List<Modifier> statusModifiers = new();

        public List<Item> items;

        public List<Spell> spells;

        protected BattleManager manager;

        protected void TurnOn()
        {
            manager = FindFirstObjectByType<BattleManager>();
            hp.Init();
            mana.Init();
            damage.Init();

            foreach (var item in items)
            {
                item.Init(this);
            }

            foreach (var spell in spells)
            {
                spell.Init(this);
            }
        }
    

        public virtual void DoDamage(int value)
        {
            hp -= value;

            if (hp == 0)
            {
                NoHp();
            }
        }
        public void Delete()
        {
            Destroy(gameObject);
        }

        public bool Stunned()
        {
            return statusModifiers.Exists(mod => mod.Type == ModType.Stun && mod.GetValue() != 0);
        }

        public abstract void Act();

        protected abstract void NoHp();
    }
}