using UnityEngine;
using System.Collections;

public class DontDestroyThisOnLoad : MonoBehaviour
{
	void Awake() 
	{
		DontDestroyOnLoad(this);
	}
}