using System.Security.Cryptography;

namespace GameBoard.Abstractions;

public abstract class GameState<TPiece>
{
	protected Dictionary<Location, (string SideName, TPiece Piece)> Pieces = [];

	/// <summary>
	/// key = SideName, value = player name
	/// </summary>
	protected Dictionary<string, string> Players = [];

	public GameState()
	{
	}

	public int Width { get; init; }
	public int Height { get; init; }
	public int CurrentSide { get; private set; }

	public string CurrentSideName => Sides[CurrentSide].Name;

	public abstract (string Name, Location Origin)[] Sides { get; }

	protected static string GetRandom(string[] values)
	{
		var index = RandomNumberGenerator.GetInt32(values.Length);
		return values[index];
	}

	protected static int GetRandom(int max) => RandomNumberGenerator.GetInt32(max);

	private Dictionary<string, string> GetPlayers(string[] playerNames) => Sides
		.Select((s, index) => (s.Name, index))
		.ToDictionary(item => item.Name, item => playerNames[item.index]);
		
	public void Initialize(params string[] playerNames)
	{
		Players = GetPlayers(playerNames);
		CurrentSide = GetRandom(Sides.Length);

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

	public void MovePiece(TPiece piece, string sideName, Location from, Location to)
	{
		Pieces[to] = (sideName, piece);
		Pieces.Remove(from);
		CurrentSide++;
		if (CurrentSide > Sides.Length - 1) CurrentSide = 0;
	}
}
