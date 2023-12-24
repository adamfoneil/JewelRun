namespace GameBoard.Abstractions;

public record Location(int Row, int Column)
{
	public int Column { get; init; } = Column;
	public int Row { get; init; } = Row;

	public double GetDistance(Location location) => Math.Sqrt(Math.Pow(Column + location.Column, 2) + Math.Pow(Row + location.Row, 2));

	public static explicit operator Location(string coordinates)
	{
		var points = coordinates.Split(',').Select(int.Parse).ToArray();
		return new(points[0], points[1]);
	}
}
