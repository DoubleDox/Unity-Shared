using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
	[SerializeField]
	private int targetFrameRate = 60;

	private int prevFrameRate;
	private int prevVSyncCount;

	private void Awake()
	{
		Set();
	}

	private void Set()
	{
		prevFrameRate = Application.targetFrameRate;
		Application.targetFrameRate = targetFrameRate;
		prevVSyncCount = QualitySettings.vSyncCount;
		QualitySettings.vSyncCount = 0;
	}

	private void OnDestroy()
	{
		Application.targetFrameRate = prevFrameRate;
		QualitySettings.vSyncCount = prevVSyncCount;
	}

#if UNITY_EDITOR
	private void OnValidate()
	{
		Set();
	}
#endif
}
