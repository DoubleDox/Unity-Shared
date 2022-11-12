using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonLoader : MonoBehaviour
{
    [SerializeField]
    GameObject managersPrefab;

    static GameObject instance; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = GameObject.Instantiate(managersPrefab);
            DontDestroyOnLoad(instance);
        }
    }
}
