using GameBoard.Abstractions;

namespace Tests
{
	[TestClass]
	public class Locations
	{
		[TestMethod]
		[DataRow("3,0", "0,4", 5)]
		public void Distance(string fromPoint, string toPoint, double expected)
		{
			var from = (Location)fromPoint;
			var to = (Location)toPoint;
			var actual = from.GetDistance(to);
			Assert.AreEqual(expected, actual);
		}
	}
}