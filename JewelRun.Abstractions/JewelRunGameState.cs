using GameBoard.Abstractions;

namespace JewelRun.Abstractions;

public class JewelRunGameState : WebGameState
{
	public override (string? CssClass, string? Style, string? Content) GetCell(int column, int row)
	{
		if (column == 3 && row == 3)
		{
			return ("gridCell", default, " <p>hello</p>");
		}

		return ("gridCell", default, $"{column}, {row}");
	}
}
