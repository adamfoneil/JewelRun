namespace JewelRun.Abstractions;

public record Location(int Row, int Column)
{
	public int Column { get; init; } = Column;
	public int Row { get; init; } = Row;
}
