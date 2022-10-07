using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CamFocusParams : ScriptableObject
{
    public int _camIndex;
    public float _focusDuration;
    public bool _useOnce = true;
    [System.NonSerialized]
    public bool _isUsed; //Est ce que cettre transition a déjà été utilisée

    public static CamFocusParams Create()
    {
        CamFocusParams _instance = (CamFocusParams)ScriptableObject.CreateInstance(typeof(CamFocusParams));

        string _path = "Assets/" + "CamFocusParams" + ".asset";
        AssetDatabase.CreateAsset(_instance, _path);
        AssetDatabase.SaveAssets();

        return _instance;
    }
}
