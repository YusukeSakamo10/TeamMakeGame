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

    // Update is called once per frame
    void Update()
    {
        if (SelectObj)
        {
            _vCam.Priority = 100;
            _vCam.Follow = _selecteObj.transform;
            _vCam.LookAt = _selecteObj.transform;
        }
        else
        {
            _vCam.Priority = 0;
        }
    }
}
