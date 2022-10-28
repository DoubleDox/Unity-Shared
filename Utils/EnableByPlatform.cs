// -----------------------------------
// author: DoubleDox, parax_85@mail.ru
// -----------------------------------
using UnityEngine;
using System.Collections;

public class EnableByPlatform : MonoBehaviour
{
    public bool Standalone;
    public bool WebGL;
    public bool Android;
    public bool IOS;

    void Awake()
    {
        gameObject.SetActive(IsFit());
    }

    public bool IsFit()
    {
#if UNITY_STANDALONE
        return Standalone;
#elif UNITY_WEBGL
        return WebGL;
#elif UNITY_ANDROID
        return Android;
#elif UNITY_IPHONE
        return IOS;
#else
        return false;
#endif
    }

    public static bool IsFitForPlatform(GameObject gameObject)
    {
        EnableByPlatform ebp = gameObject.GetComponent<EnableByPlatform>();
        return (ebp == null || ebp.IsFit());
    }
}
