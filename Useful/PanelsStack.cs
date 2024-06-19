
using System.Collections.Generic;
using UnityEngine;

public static class PanelsStack
{
	static List<IStackablePanel> stackablePanels = new List<IStackablePanel>();

	public static void Stack(IStackablePanel panel)
	{
		stackablePanels.Add(panel);
	}

	public static void UnStack(IStackablePanel panel)
	{
		stackablePanels.Remove(panel);
	}

	public static bool HasStackables => stackablePanels.Count > 0;

	public static bool IsTop(IStackablePanel panel)
	{
		return stackablePanels[^1] == panel;
	}
}