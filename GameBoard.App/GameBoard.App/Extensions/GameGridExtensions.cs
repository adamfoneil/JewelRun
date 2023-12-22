using GameBoard.Abstractions;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace GameBoard.App.Extensions;

public static class GameGridExtensions
{
	public static MarkupString Css(this GameGrid gameGrid) =>
		new(@$"border: 1px gray solid;
			width:93vw;
			height:93vh;
			grid-template-rows:repeat({gameGrid.Height}, 1fr);
			grid-template-columns:repeat({gameGrid.Width}, 1fr);");

	public static MarkupString Body(this GameGrid gameGrid)	
	{
		StringBuilder sb = new();

		for (int x = 1; x <= gameGrid.Width; x++)
		{
			for (int y = 1;  y <= gameGrid.Height; y++)
			{
				sb.Append($"<div id=\"square-{x}-{y}\" class=\"gridCell\">{x}, {y}</div>");
			}
		} 

		return new(sb.ToString());
	}
		
}
