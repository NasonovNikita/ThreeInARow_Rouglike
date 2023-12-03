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

            manager.player.mana -= useCost;
            foreach (var enemy in manager.enemies)
            {
                enemy.stateModifiers.Add(new Modifier(count, ModType.Blind));
            }
        }
    }
}