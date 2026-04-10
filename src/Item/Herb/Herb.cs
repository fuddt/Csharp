public class Herb : Item
{
    private readonly int _healAmount;

    public Herb(string name, string description, int healAmount)
        : base(name, description)
    {
        _healAmount = healAmount;
    }

    public override void Use(Player player)
    {
        player.Heal(_healAmount);
    }
}

public class GreenHerb : Herb
{
    public GreenHerb() : base("Green Herb", "少量の体力を回復", 30) { }
}

public class RedHerb : Herb
{
    public RedHerb() : base("Red Herb", "中程度の体力を回復", 60) { }
}
