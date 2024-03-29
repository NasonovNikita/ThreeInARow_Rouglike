using UnityEngine;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "MagicShield", menuName = "Spells/MagicShield")]
    public class MagicShield : Spell
    {
        public override void Cast()
        {
            if (CantCast()) return;
            
            // ReSharper disable once Unity.NoNullPropagation
            useAble?.Use();
        }
    }
}