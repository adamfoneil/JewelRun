namespace JewelRun.Abstractions;

public class Player
{
    private Player()
    {            
    }

    public static Player Create(string name)
    {
        var runners = Runner.Names.Select(name => new { Name = name, Runner = Runner.Create() });
       
        return new Player()
        { 
            Name = name,
            Runners = runners.Select(r => r.Runner).ToArray(),
            RunnersByName = runners.ToDictionary(r => r.Name, r => r.Runner),
            Jeweler = runners.MaxBy(r => r.Runner.Score)!.Name 
        };
    }

    public required string Name { get; init; } = default!;
	public required Runner[] Runners { get; init; } = Array.Empty<Runner>();
	public Dictionary<string, Runner> RunnersByName { get; private set; } = new();
	public required string Jeweler { get; init; } = default!;
}
