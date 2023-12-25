using GameBoard.Abstractions;

namespace JewelRun.Abstractions;

public class JewelRunGameState : GameState<Runner>
{
	public JewelRunGameState()
	{
		Width = 16;
		Height = 12;
	}

	public static Location EastEndZone => new(1, 16);

	public static Location WestEndZone => new(12, 1);

	private static Location[] EastStartingLocations =>
	[
		new(1, 14),
		new(1, 15),
		new(2, 14),
		new(2, 15),
		new(2, 16),
		new(3, 15),
		new(3, 16)
	];

	private static Location[] WestStartingLocations =>
	[
		new(10, 1),
		new(10, 2),
		new(11, 1),
		new(11, 2),
		new(11, 3),
		new(12, 2),
		new(12, 3)
	];

	public override (string, Location)[] Sides => [("East", EastEndZone), ("West", WestEndZone)];

	protected override IEnumerable<(Location Location, Runner Piece)> GetDefaultPieces(Location origin) =>
		(origin == EastEndZone) ? Runner.Names.Select((nameSet, index) => (EastStartingLocations[index], Runner.Create(GetRandom(nameSet)))) :
		(origin == WestEndZone) ? Runner.Names.Select((nameSet, index) => (WestStartingLocations[index], Runner.Create(GetRandom(nameSet)))) :
		throw new Exception("hello");

	public Dictionary<string, string> JewelCarriers { get; private set; } = [];

	protected override void AfterInitialize(IEnumerable<(string SideName, Location Location, Runner Piece)> allPieces)
	{
		// the two pieces on each side with the lowest overall score are the jewel carriers
		JewelCarriers = allPieces.GroupBy(p => p.SideName).ToDictionary(grp => grp.Key, grp => grp.MinBy(p => p.Piece.Score).Piece.Name);
	}

	public bool IsJewelCarrier(string sideName, Runner runner) => JewelCarriers[sideName].Equals(runner.Name);
}
