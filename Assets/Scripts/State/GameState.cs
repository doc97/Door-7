/* Singleton for storing global game state */
public sealed class GameState
{
    private static readonly GameState instance = new GameState();

    static GameState() {}
    private GameState() {}

    public static GameState Instance { get { return instance; } }
}