using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ObjectCameraController : MonoBehaviour
{
    GameObject _selecteObj;
    private CinemachineVirtualCamera _vCam;
    public GameObject SelectObj
    {
        get { return _selecteObj; }
        set { _selecteObj = value; }
    }
    private void Start()
    {
        _vCam = GetComponent<CinemachineVirtualCamera>();
        if (_vCam) _vCam.Priority = 0;
    }
    int time = 60;


    // Update is called once per frame
    void Update()
    {
        if (SelectObj)
        {
            _vCam.Priority = 100;
            _vCam.LookAt = _selecteObj.transform;
            if (time > 0)
            {
                _vCam.Follow = _selecteObj.transform;
                time--;
            }
            else
            {
                _vCam.Follow = null;
            }
        }
        else
        {
            time = 60;
            _vCam.Priority = 0;
        }
    }
}
