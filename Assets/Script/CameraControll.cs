using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    void Start()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public float GetAxisCustom(string axisName)
    {
        //水平方向に移動しながらマウスでも回転するとカクつくので制御している
        if (Input.GetKey(KeyCode.D)) { return 0; }
        else if (Input.GetKey(KeyCode.A)) { return 0; }
        //マウスのX軸方向の移動取得
        
        if (Input.GetMouseButton(1))
        {
            if (axisName == "Mouse X")
            {
               return UnityEngine.Input.GetAxis("Mouse X");
            }
            //マウスのY軸方向の取得
            else if (axisName == "Mouse Y")
            {
               return UnityEngine.Input.GetAxis("Mouse Y");
            }
            return 0;
        }
        return 0;
    }
}
