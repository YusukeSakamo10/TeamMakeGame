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
        //���������Ɉړ����Ȃ���}�E�X�ł���]����ƃJ�N���̂Ő��䂵�Ă���
        if (Input.GetKey(KeyCode.D)) { return 0; }
        else if (Input.GetKey(KeyCode.A)) { return 0; }
        //�}�E�X��X�������̈ړ��擾
        else if (axisName == "Mouse X")
        {
            if (Input.GetMouseButton(1))
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            }
            return 0;
        }
        //�}�E�X��Y�������̎擾
        else if (axisName == "Mouse Y")
        {
            if (Input.GetMouseButton(1))
            {
                return UnityEngine.Input.GetAxis("Mouse Y");
            }
            return 0;
        }
        return 0;
    }
}
