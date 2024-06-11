using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class TaskDelayUni
{
    public static async Task DelayWebGL(float seconds)
    {
        float start = Time.time;

        while (Time.time < start + seconds)
            await Task.Yield();
    }

    public static async Task Delay(float seconds)
    {
#if !UNITY_WEBGL
        await Task.Delay(Mathf.RoundToInt(seconds * 1000));
#else
        await DelayWebGL(seconds);
#endif
	}
}
