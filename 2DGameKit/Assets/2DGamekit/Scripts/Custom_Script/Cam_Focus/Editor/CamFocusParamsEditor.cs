using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CamFocusParams))]
public class CamFocusParamsEditor : Editor
{
    CamFocusParams _target;

    private void OnEnable()
    {
        _target = (CamFocusParams)target;
    }

    private void OnDisable()
    {
        //string _name = "Focus Params: Focus to cam " + _target._camIndex + " for " + _target._focusDuration + " seconds";
        string _name = "Focus_Params_Focus_to_cam_" + _target._camIndex + "_for_" + _target._focusDuration + "_seconds";

        string assetPath = AssetDatabase.GetAssetPath(_target);
        AssetDatabase.RenameAsset(assetPath, _name);
        AssetDatabase.SaveAssets();

    }
}
