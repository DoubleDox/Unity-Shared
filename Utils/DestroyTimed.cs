using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DestroyTimed : MonoBehaviour
{
    [SerializeField]
    float timeOut = 1.0f;

    async void Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        await Task.Delay((int)(timeOut * 1000));
#else
        Debug.LogError("async delay may not be supported in webgl; need alternative solution");
#endif
        if (!Equals(null))
            GameObject.Destroy(gameObject);
    }

    public static void Do(GameObject target, float timeOut)
    {
        var dt = target.AddComponent<DestroyTimed>();
        dt.timeOut = timeOut;
    }
}
