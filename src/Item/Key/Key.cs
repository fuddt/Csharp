public class Key : Item
{
    private readonly string _keyId;

    public Key(string keyId) : base("Key", "扉を開ける鍵")
    {
        _keyId = keyId;
    }

    public override void Use(Player player)
    {
        Console.WriteLine($"[{_keyId}] を使った。扉が開いた。");
    }
}
