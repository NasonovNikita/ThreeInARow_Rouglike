public class StrongerKick : Spell
{
    protected override int ManaCost => 25;
    protected override int Moves => 1;

    private const float Value = 0.3f;

    public override void Cast()
    {
        if (manager.State != BattleState.PlayerTurn || player.Mana < ManaCost) return;
        
        player.ChangeMana(-ManaCost);
        player.DamageModifiers.Add(new Modifier(Moves, ModifierType.DamageMul, Value));
    }
}