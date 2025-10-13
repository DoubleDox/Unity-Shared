using UnityEngine;

public abstract class FXManagerBase : MonoBehaviour
{
	public static FXManagerBase instance { get; private set; }

	protected virtual void Awake()
	{
		instance = this;
	}

	protected virtual void OnDestroy()
	{
		instance = null;
	}

	public abstract bool PlayFX(string fxEvent, GameObject source);
}
