using Battle.Modifiers;
using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "MagicShield", menuName = "Spells/MagicShield")]
    public class MagicShield : Spell
    {
        public override void Cast()
        {
            if (CantCast()) return;
        
            manager.player.mana.Waste(useCost);
            LogUsage();
            manager.player.AddHpMod(new Modifier(count, ModType.Mul, ModClass.HpDamageBase, value: -value));
        }

        public override string Title => "Magic Shield";

        public override string Description => $"Get {Other.Tools.Percents(value)}% less damage this turn";
    }
}