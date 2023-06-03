using System.Collections.Generic;

public static class BattleLogs
{
    public static MyList<ILog> Logs { get; } = new();
}

public class GridLog : ILog
{
    private readonly Dictionary<GemType, int> _table;
    
    public static void Log(Dictionary<GemType, int> table) => ILog.AddLog(new GridLog(table));

    public Dictionary<GemType, int> GetData() => _table;

    private GridLog(Dictionary<GemType, int> table) => _table = table;
}

public class DeathLog : ILog
{
    private readonly Unit _unit;
    
    public static void Log(Unit unit) => ILog.AddLog(new DeathLog(unit));

    public Unit GetData() => _unit;

    private DeathLog(Unit unit) => _unit = unit;
}

public class PToEDamageLog : DamageLog, ILog
{
    public static void Log(Enemy enemy, Player player, int damage) => ILog.AddLog(new PToEDamageLog(enemy, player, damage));

    private PToEDamageLog(Enemy enemy, Player player, int damage) : base(enemy, player, damage) {}
}

public class EToPDamageLog : DamageLog, ILog
{
    public static void Log(Enemy enemy, Player player, int damage) => ILog.AddLog(new EToPDamageLog(enemy, player, damage));

    private EToPDamageLog(Enemy enemy, Player player, int damage) : base(enemy, player, damage) {}
}

public class DamageLog
{
    private readonly Enemy _enemy;
    private readonly Player _player;
    private readonly int _damage;
    
    public (Enemy, Player, int) GetData() => (_enemy, _player, _damage);

    protected DamageLog(Enemy enemy, Player player, int damage)
    {
        _enemy = enemy;
        _player = player;
        _damage = damage;
    }
}

public interface ILog
{
    protected internal static void AddLog(ILog log) => BattleLogs.Logs.Add(log);
}