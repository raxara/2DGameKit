using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(CamFocusCtrl))]
public class CamFocusCtrlEditor : Editor
{
    CamFocusCtrl _target;
    int _camIndex = 0;

    private void OnEnable()
    {
        _target = (CamFocusCtrl)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            EditorGUI.BeginChangeCheck();
            _camIndex = EditorGUILayout.IntField("Cam to display", _camIndex);

            if (EditorGUI.EndChangeCheck())
            {
                _target.DisplayCam(_camIndex);
            }

        }

        CreateDisplayFocusParams();
    }

    void CreateDisplayFocusParams()
    {
      if(GUILayout.Button("Create Focus Params"))  CamFocusParams.Create();
    }
}
