using GameBoard.Abstractions;
using System.Security.Cryptography;

namespace JewelRun.Abstractions;

public class Runner
{
	private Runner(string name)
	{			
		Name = name;
	}

	public static Runner Create(string name) => new(name)
	{
		Awareness = GetRandom(1, 4),
		Attack = GetRandom(1, 3),
		Defense = GetRandom(1, 3),
		Mobility = GetRandom(3, 7)
	};

	public bool AllowMove(Location from, Location to) => from.GetDistance(to) <= Mobility;

	private static int GetRandom(int min, int max) => RandomNumberGenerator.GetInt32(min, max);

	public string Name { get; init; }
	public int Awareness { get; init; }
	public int Attack { get; init; }
	public int Defense { get; init; }
	public int Mobility { get; init; }
	public int Score => Awareness + Attack + Defense + Mobility;
	
	public static string[][] Names =>
	[
		[ "Ajax", "Acrid", "Avon" ],
		[ "Brunswick", "Banjo", "Boom" ],
		[ "Comet", "Cathode", "Carbon" ],
		[ "Doodle", "Damsel", "Darius" ],
		[ "Ember", "Engine", "Euclid" ],
		[ "Fancy", "Frame" ],
		[ "Garlic", "Gallium" ]
	];
}
