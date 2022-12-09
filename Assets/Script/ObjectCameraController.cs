using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ObjectCameraController : MonoBehaviour
{
    //�I�����ꂽ�I�u�W�F�N�g��ۊǂ���悤
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
        //�I�u�W�F�N�g������̂��I�����ꂽ�Ƃ��Ȃ̂ŃI�u�W�F�N�g������΂͂���
        if (SelectObj)
        {
            //�J�����̗D��x��������
            _vCam.Priority = 100;
            //���߂�Ώۂ�I�����ꂽ�I�u�W�F�N�g��
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
