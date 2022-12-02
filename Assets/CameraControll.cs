using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    private CinemachineVirtualCamera _vCam;

    void Start()
    {
        //_vCam = GetComponent<CinemachineVirtualCamera>();
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public float GetAxisCustom(string axisName)
    {
        //水平方向に移動しながらマウスでも回転するとカクつくので制御している
        if (Input.GetKey(KeyCode.D)){ return 0; }
        else if(Input.GetKey(KeyCode.A)){ return 0; }
        else
        {
            if (Input.GetMouseButton(1))
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            }
            return 0;
        }
    }
}
