using System.Security.Cryptography;

namespace JewelRun.Abstractions;

public class Runner
{
	private Runner()
	{			
	}

	public static Runner Create() => new()
	{
		Awareness = GetRandom(1, 4),
		Attack = GetRandom(1, 3),
		Defense = GetRandom(1, 3),
		Mobility = GetRandom(3, 7)
	};

	private static int GetRandom(int min, int max) => RandomNumberGenerator.GetInt32(min, max);

	public int Awareness { get; init; }
	public int Attack { get; init; }
	public int Defense { get; init; }
	public int Mobility { get; init; }
	public int Score => Awareness + Attack + Defense + Mobility;
	
	public static string[][] Names =>
	[
		[ "Ajax", "Acrid", "Apple" ],
		[ "Brunswick", "Banjo", "Boom" ],
		[ "Comet", "Cathode", "Carbon" ],
		[ "Doodle", "Damsel" ],
		[ "Ember", "Engine", "Euclid" ],
		[ "Fancy", "Frame" ],
		[ "Garlic", "Gallium" ]
	];
}
