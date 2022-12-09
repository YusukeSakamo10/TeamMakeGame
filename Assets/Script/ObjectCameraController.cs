using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ObjectCameraController : MonoBehaviour
{
    //選択されたオブジェクトを保管するよう
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
    int time = 120;


    // Update is called once per frame
    void Update()
    {
        //オブジェクトが入るのが選択されたときなのでオブジェクトがあればはいる
        if (SelectObj)
        {
            //カメラの優先度をあげる
            _vCam.Priority = 100;
            //見つめる対象を選択されたオブジェクトへ
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
            time = 120;
            _vCam.Priority = 0;
        }
    }
}
