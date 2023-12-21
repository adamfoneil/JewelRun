namespace JewelRun.Abstractions;

public class Game
{
	public int Width { get; init; }
	public int Height { get; init; }

	/// <summary>
	/// who's turn is it? (player name)
	/// </summary>
	public string CurrentTurn { get; private set; } = default!;

	public Dictionary<string, Player> PlayersByName { get; init; } = [];
	public Dictionary<(string, string), RunnerState> RunnerStates { get; init; } = [];

	public class RunnerState
	{
		public Location Location { get; private set; }
		public bool IsAlive { get; private set; } = true;
		public bool IsVisible { get; private set; } = true;

		public void SetIsAlive(bool isAlive) { IsAlive = isAlive; }
		public void SetIsVisible(bool isVisible) { IsVisible = isVisible; }
		public void SetLocation(Location location) { Location = location; }				
	}
}
