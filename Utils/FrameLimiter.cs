using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{ 
    [SerializeField]
    private int targetFrameRate = 60;

    private void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
    }

    private void OnDestroy()
    {
        Application.targetFrameRate = 0;
    }

    private void OnValidate()
    {
        Application.targetFrameRate = targetFrameRate;
    }
}
