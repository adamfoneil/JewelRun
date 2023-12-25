using GameBoard.Abstractions;
using Microsoft.AspNetCore.Components;

namespace GameBoard.App.Extensions;

public static class GameGridExtensions
{
	public static MarkupString Css<TPiece>(this GameState<TPiece> gameGrid) =>
		new(@$"border: 1px gray solid;
			width:93vw;
			height:93vh;
			grid-template-rows:repeat({gameGrid.Height}, 1fr);
			grid-template-columns:repeat({gameGrid.Width}, 1fr);");
}
