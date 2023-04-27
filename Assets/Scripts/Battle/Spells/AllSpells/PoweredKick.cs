public class PoweredKick : Spell
{
    protected override int ManaCost => 45;
    
    protected override int Moves => 1;

    private const float Value = 2.0f;

    public override void Cast()
    {
        if (CanCast()) return;
        
        BattleManager.Player.mana -= ManaCost;
        BattleManager.Player.statusModifiers.Add(new Modifier(Moves, ModifierType.Stun, BattleManager.Player.statusModifiers,() => true));
        BattleManager.Player.damage.onGetMods.Add(new Modifier(Moves,ModifierType.Mul, BattleManager.Player.damage.onGetMods, () => true, Value));
        Manager.EndTurn();
    }
}