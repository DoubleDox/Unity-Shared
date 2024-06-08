using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
	[SerializeField]
	private int targetFrameRate = 60;

	private int prevFrameRate;

	private void Awake()
	{
		Set();
	}

	private void Set()
	{
#if UNITY_STANDALONE_WIN
		prevFrameRate = Application.targetFrameRate;
        Application.targetFrameRate = targetFrameRate;
#else
		prevFrameRate = QualitySettings.vSyncCount;
		QualitySettings.vSyncCount = targetFrameRate;
#endif

	}

	private void OnDestroy()
	{
#if UNITY_STANDALONE_WIN
        Application.targetFrameRate = prevFrameRate;
#else
		QualitySettings.vSyncCount = prevFrameRate;
#endif
	}

#if UNITY_EDITOR
	private void OnValidate()
	{
		Set();
	}
#endif
}
