using GameBoard.Abstractions;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace GameBoard.App.Extensions;

public static class GameGridExtensions
{
	public static MarkupString Css(this WebGameState gameGrid) =>
		new(@$"border: 1px gray solid;
			width:93vw;
			height:93vh;
			grid-template-rows:repeat({gameGrid.Height}, 1fr);
			grid-template-columns:repeat({gameGrid.Width}, 1fr);");

	public static MarkupString Body(this WebGameState gameGrid)	
	{
		StringBuilder sb = new();

		for (int col = 1; col <= gameGrid.Width; col++)
		{
			for (int row = 1;  row <= gameGrid.Height; row++)
			{
				var (CssClass, Style, Content) = gameGrid.GetCell(col, row);
				sb.Append($"<div id=\"square-{col}-{row}\" class=\"{CssClass}\" style=\"{Style}\">{Content}</div>");
			}
		} 

		return new(sb.ToString());
	}
		
}
