using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStackablePanel : MonoBehaviour, IStackablePanel
{
	private void OnEnable()
	{
		PanelsStack.Stack(this);
	}

	private void OnDisable()
	{
		PanelsStack.UnStack(this);
	}
}

public interface IStackablePanel
{
	bool IsTop => PanelsStack.IsTop(this);
}