using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CamFocusCtrl : MonoBehaviour
{
    public List<CinemachineVirtualCamera> _cameraList;


    public void DisplayCam(int _camIndex)
    {
        if (_camIndex < 0 || _camIndex >= _cameraList.Count)
        {
            Debug.Log("Cam index is out of range!");
            return;
        }

        foreach (var _cam in _cameraList)
        {
            _cam.gameObject.SetActive(false);
        }

        _cameraList[_camIndex].gameObject.SetActive(true);
    }

    public void DisplayCamForSeconds(CamFocusParams _params)
    {
        if (_params._useOnce && _params._isUsed) return;
        StartCoroutine(DisplayCamForSecondsCorout(_params));
    }

    IEnumerator DisplayCamForSecondsCorout(CamFocusParams _params)
    {
        int _activeCamIndex = GetactiveCamIndex();

        int _camIndex = (int)_params._camIndex;

        DisplayCam(_camIndex);

        _cameraList[_camIndex].gameObject.SetActive(true);

        yield return new WaitForSeconds(_params._focusDuration);

        DisplayCam(_activeCamIndex);

        _params._isUsed = true;
    }

    int GetactiveCamIndex()
    {
        for (int i = 0; i < _cameraList.Count; i++)
        {
            if (_cameraList[i].gameObject.activeSelf) return i;
        }

        return -1;
    }

    [System.Serializable]
    public struct Params
    {
        public int _test1;
        public int _test2;

    }
}
