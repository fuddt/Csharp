var player = new Player();

player.AddItem(new GreenHerb());
player.AddItem(new RedHerb());
player.AddItem(new Key("ボスルームの鍵"));

player.Damage(80);
PrintStatus(player);

player.UseItem(0);
PrintStatus(player);

player.UseItem(0);
PrintStatus(player);

player.UseItem(0);
PrintStatus(player);

static void PrintStatus(Player p)
{
    Console.WriteLine($"HP: {p.Hp}/{p.MaxHp}  [{p.Condition}]  Items: {p.ItemCount}");
}
