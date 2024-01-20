using System.Linq;
using Battle.Modifiers;
using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "FlashOfLight", menuName = "Spells/FlashOfLight")]
    public class FlashOfLight : Spell
    {
        public override void Cast()
        {
            if (CantCast()) return;

            manager.player.mana.Waste(useCost);
            LogUsage();
            foreach (var enemy in manager.enemies.Where(v => v != null))
            {
                enemy.AddMod(new Modifier(count, ModType.Blind));
            }
        }

        public override string Title => "Flash Of Light";

        public override string Description => "Enemies can't see the grid (they do random things)";
    }
}