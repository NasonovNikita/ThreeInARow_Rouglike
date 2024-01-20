using Battle.BattleEventHandlers;
using Battle.Units;
using UnityEngine;

namespace Battle.Items
{
    [CreateAssetMenu(fileName = "PassiveBomb", menuName = "Items/PassiveBomb")]
    public class PassiveBomb : Item
    {
        [SerializeField] private int minMana;
        [SerializeField] private int damage;
        public override void Use(Unit unitBelong)
        {
            BattleManager manager = FindFirstObjectByType<BattleManager>();
            new EveryTurn(() =>
            {
                if (unitBelong.mana < minMana) return;
                foreach (Enemy enemy in manager.enemies)
                {
                    Damage dmg = new Damage(fDmg: damage);
                    enemy.DoDamage(dmg);
                    PToEDamageLog.Log(enemy, manager.player, dmg);
                }
            });
        }

        public override string Title => "Passive Bomb";

        public override string Description =>
            $"If at the end of the turn you have at least {minMana} mana you throw a bomb, that deals {damage} fire dmg to enemies";
    }
}