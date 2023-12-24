using JewelRun.Abstractions;

namespace GameBoard.Abstractions;

public abstract class GameState<TPiece>
{
	protected Dictionary<Location, (string SideName, TPiece Piece)> Pieces = [];
	protected Dictionary<string, string> Players = [];

	public GameState()
	{
	}

	public int Width { get; init; }
	public int Height { get; init; }

	public abstract (string Name, Location Origin)[] Sides { get; }

	private Dictionary<string, string> GetPlayers(string[] playerNames) => Sides
		.Select((s, index) => (s.Name, index))
		.ToDictionary(item => item.Name, item => playerNames[item.index]);
		
	public void Initialize(params string[] playerNames)
	{
		Players = GetPlayers(playerNames);

		List<(string SideName, Location Location, TPiece Piece)> pieces = [];

		var allPieces = Sides
            .SelectMany(side => GetDefaultPieces(side.Origin), (side, piece) => new { side, piece })
			.Select(item => (item.side.Name, item.piece.Location, item.piece.Piece))
			.ToArray();

		pieces.AddRange(allPieces);

		Pieces = pieces.ToDictionary(row => row.Location, row => (row.SideName, row.Piece));

		AfterInitialize(allPieces);
	}

	protected virtual void AfterInitialize(IEnumerable<(string SideName, Location Location, TPiece Piece)> allPieces) { }

	protected abstract IEnumerable<(Location Location, TPiece Piece)> GetDefaultPieces(Location origin);

	public (string SideName, TPiece? Piece) GetPiece(Location location) => HasPiece(location, out var info) ? info : default;

	public bool HasPiece(Location location, out (string SideName, TPiece Piece) result) => Pieces.TryGetValue(location, out result);
}
