namespace GameBoard.Abstractions;

public class MoveArgs
{
	public bool IsValid { get; set; }
	public Location SourceLocation { get; set; } = new(0, 0);
	public Location TargetLocation { get; set; } = new(0, 0);
}
