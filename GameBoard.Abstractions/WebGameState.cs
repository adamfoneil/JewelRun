namespace GameBoard.Abstractions;

public abstract class WebGameState
{
	public WebGameState()
	{
	}

	public int Width { get; init; }
	public int Height { get; init; }

	public abstract (string? CssClass, string? Style, string? Content) GetCell(int column, int row);
}
