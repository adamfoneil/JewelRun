
using System.Security.Cryptography;

namespace JewelRun.Abstractions;

public class Player
{
	private Player()
	{
	}

	public static Player Create(string name)
	{
		var runners = Runner.Names.Select(nameSet => new { Name = GetRandom(nameSet), Runner = Runner.Create() });

		return new Player()
		{
			Name = name,
			Runners = runners.Select(r => r.Runner).ToArray(),
			RunnersByName = runners.ToDictionary(r => r.Name, r => r.Runner),
			Jeweler = runners.MinBy(r => r.Runner.Score)!.Name
		};
	}

	private static string GetRandom(string[] values)
	{
		var index = RandomNumberGenerator.GetInt32(values.Length);
		return values[index];
	}
	
	public required string Name { get; init; } = default!;
	public required Runner[] Runners { get; init; } = [];
	public Dictionary<string, Runner> RunnersByName { get; private set; } = [];
	public required string Jeweler { get; init; } = default!;
}
