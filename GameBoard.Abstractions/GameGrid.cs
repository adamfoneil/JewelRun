namespace GameBoard.Abstractions;

public class GameGrid
{
    public GameGrid()
    {            
    }

    public static GameGrid Create(int width,  int height) => new() { Width = width, Height = height };

    public int Width { get; init; }
	public int Height { get; init; }
}
