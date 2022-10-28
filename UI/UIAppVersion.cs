// -----------------------------------
// author: DoubleDox, parax_85@mail.ru
// -----------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIAppVersion : MonoBehaviour
{
    public string versionPreffix;

    void Awake()
    {
        GetComponent<Text>().text = versionPreffix + Application.version;
    }
}
