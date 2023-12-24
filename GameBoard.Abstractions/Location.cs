namespace JewelRun.Abstractions;

public readonly struct Location(int column, int row)
{
	public int Column { get; init; } = column;
	public int Row { get; init; } = row;
}
