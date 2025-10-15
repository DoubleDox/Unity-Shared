
using UnityEngine;

public abstract class LocalizationHandler : MonoBehaviour
{
	public static LocalizationHandler instance { get; private set; }

	protected virtual void Awake()
	{
		instance = this;
	}

	protected virtual void OnDestroy()
	{
		instance = null;
	}

	public abstract string LocalizeKey(string key);

	public static string Localize(string key)
	{
		if (instance != null)
			return instance.LocalizeKey(key);
		return key;
	}
}
