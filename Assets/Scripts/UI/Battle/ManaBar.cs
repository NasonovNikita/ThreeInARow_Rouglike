using Battle.Units.Stats;

namespace UI.Battle
{
    public class ManaBar : StatBar
    {
        protected override Stat stat => unit.mana;
    }
}