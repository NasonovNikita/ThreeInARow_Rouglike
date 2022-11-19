public class Kick : Spell
{
    protected override int ManaCost => 50;
    protected override int Moves => 1;

    private int Value = 100;

    public override void Cast()
    {
        if (manager.State != BattleState.PlayerTurn) return;
        
        player.ChangeMana(-ManaCost);
        player.DamageModifiers.Add(new Modifier(Moves, ModifierType.DamageAdd, Value));
    }
}