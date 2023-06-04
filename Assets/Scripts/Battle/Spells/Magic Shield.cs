using Battle.Units;
using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "MagicShield", menuName = "Spells/MagicShield")]
    public class MagicShield : Spell
    {
        [SerializeField] private int moves;

        [SerializeField] private float value;
        
        public override void Cast()
        {
            if (CantCast()) return;
            
            Modifier.CreateModifier(BattleManager.player, moves, ModType.Mul, ModAffect.Sub, StatType.Hp, value);
        }
    }
}