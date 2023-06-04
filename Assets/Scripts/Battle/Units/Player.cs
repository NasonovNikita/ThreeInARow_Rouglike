using System;
using System.Linq;
using Audio;
using Battle.Match3;
using Battle.Units.Data;
using Battle.Units.Enemies;
using Grid = Battle.Match3.Grid;

namespace Battle.Units
{
    [Serializable]
    public class Player : Unit
    {
        public static PlayerData data;
    
        public int manaPerGem;

        private Grid _grid;

        public new void TurnOn()
        {
            base.TurnOn();
            _grid = FindFirstObjectByType<Grid>();
        }

        private int CountMana()
        {
            return _grid.destroyed.ContainsKey(GemType.Mana) ? _grid.destroyed[GemType.Mana] * manaPerGem : 0;
        }

        private int CountDamage()
        {
            return (int) (BattleManager.Logs.FindAndCast<GridLog>()[0].Data().Where(pair => pair.Key != GemType.Mana)
                .Sum(pair => pair.Value) * damage.GetValue());
        }

        public override void Act()
        {
            mana += CountMana();
            int doneDamage = CountDamage();
            DamageLog.Log(this, BattleManager.target, doneDamage);
            BattleManager.target.DoDamage(doneDamage);
        }

        public override void DoDamage(int value)
        {
            base.DoDamage(value);
        
            if (value != 0)
            {
                AudioManager.instance.Play(AudioEnum.PlayerHit);
            }
        }

        protected override void NoHp()
        {
            DeathLog.Log(this);
            StartCoroutine(manager.Die());
        }

        public void Load()
        {
            manaPerGem = data.manaPerGem;
            hp = data.hp;
            mana = data.mana;
            damage = data.damage;
            statusModifiers = data.statusModifiers;
            items = data.items;
            spells = data.spells;
        }

        public void Save()
        {
            data.manaPerGem = manaPerGem;
            data.hp = hp;
            data.mana = mana;
            data.damage = damage;
            data.statusModifiers = statusModifiers;
            data.items = items;
            data.spells = spells;
        }
    }
}