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

	public void SetIsAlive(bool isAlive) { IsAlive = isAlive; }
	public void SetIsVisible(bool isVisible) { IsVisible = isVisible; }

	public bool IsAlive { get; private set; }
	public bool IsVisible { get; private set; }	

	public static string[] Names =>
	[
		"Apple",
		"Banjo",
		"Comet",
		"Doodle",
		"Ember",
		"Fancy",
		"Garlic"
	];
}
