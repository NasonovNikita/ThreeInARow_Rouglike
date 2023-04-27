public class Kick : Spell
{
    protected override int ManaCost => 50;
    protected override int Moves => 1;

    private const int Value = 80;

    public override void Cast()
    {
        if (CanCast()) return;
        
        BattleManager.Player.mana -= ManaCost;
        BattleManager.target.DoDamage(Value);
    }
}