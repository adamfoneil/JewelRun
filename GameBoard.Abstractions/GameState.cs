using JewelRun.Abstractions;

namespace GameBoard.Abstractions;

public abstract class GameState<TPiece>
{
	protected Dictionary<Location, (string PlayerName, TPiece Piece)> Pieces = [];

	public GameState()
	{
	}

	public int Width { get; init; }
	public int Height { get; init; }

	public void Initialize(string[] playerNames)
	{
		List<(string, Location, TPiece)> pieces = [];

		var allPieces = playerNames
			.SelectMany(GetDefaultPieces, (name, piece) => new { name, piece })
			.Select(item => (item.name, item.piece.Location, item.piece.Piece));

		pieces.AddRange(allPieces);

		Pieces = pieces.ToDictionary(row => row.Item2, row => (row.Item1, row.Item3));
	}

	protected abstract IEnumerable<(Location Location, TPiece Piece)> GetDefaultPieces(string playerName);

	public (string PlayerName, TPiece? Piece) GetPiece(Location location) => Pieces.TryGetValue(location, out var piece) ? piece : default;
}
