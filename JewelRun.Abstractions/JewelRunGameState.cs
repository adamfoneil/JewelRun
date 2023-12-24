using GameBoard.Abstractions;

namespace JewelRun.Abstractions;

public class JewelRunGameState : GameState<Runner>
{
    public JewelRunGameState()
    {
		Width = 10;
		Height = 10;
    }

	protected override IEnumerable<(Location Location, Runner Piece)> GetDefaultPieces(string playerName)
	{
		throw new NotImplementedException();
	}
}
