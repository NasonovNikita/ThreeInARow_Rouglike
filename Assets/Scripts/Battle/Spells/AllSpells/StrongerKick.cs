public class StrongerKick : Spell
{
    protected override int ManaCost => 20;
    protected override int Moves => 1;

    private const float Value = 0.3f;

    public override void Cast()
    {
        if (manager.State != BattleState.PlayerTurn) return;
        
        player.ChangeMana(-ManaCost);
        player.DamageModifiers.Add(new Modifier(Moves, ModifierType.DamageMul, Value));
    }
}