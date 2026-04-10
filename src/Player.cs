public class Player
{
    private int _hp = 100;
    private readonly int _maxHp = 100;
    private Condition _condition = Condition.Fine;
    private readonly List<Item> _inventory = new();

    public int Hp => _hp;
    public int MaxHp => _maxHp;
    public Condition Condition => _condition;
    public int ItemCount => _inventory.Count;

    public void Heal(int amount)
    {
        _hp = Math.Min(_hp + amount, _maxHp);
        UpdateCondition();
    }

    public void Damage(int amount)
    {
        _hp = Math.Max(_hp - amount, 0);
        UpdateCondition();
    }

    private void UpdateCondition()
    {
        float ratio = (float)_hp / _maxHp;
        _condition = ratio > 0.67f ? Condition.Fine
                   : ratio > 0.33f ? Condition.Caution
                   : Condition.Danger;
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public void UseItem(int index)
    {
        if (index < 0 || index >= _inventory.Count) return;
        _inventory[index].Use(this);
        _inventory.RemoveAt(index);
    }
}
