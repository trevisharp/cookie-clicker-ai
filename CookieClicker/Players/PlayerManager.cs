namespace CoockieClicker.Players;

public class PlayerManager
{
    public PlayerManager(Player player)
        => this.Player = player;

    public Game Game { get; set; } = new Game();
    public Player Player { get; set; }
}