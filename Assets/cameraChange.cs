using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraChange : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _hucanCam = null;
    [SerializeField] CinemachineVirtualCamera _objCam = null;
    [SerializeField] CinemachineVirtualCameraBase brainCamera = null;
    bool cameraFlag = false;
    CinemachineBrain brain;
    [SerializeField] PlayerMove _playerMove = null;
    bool _hukanCamera = false;

    public bool IshukanCamera
    {
        get { return _hukanCamera; }
        set { _hukanCamera = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerMove p = GameObject.Find("Majo").GetComponent<PlayerMove>();
        _playerMove = p;

        //�V�l�}�V�[���u���C�����擾�imaincamera�ɂ��Ă�j
        brain = CinemachineCore.Instance.FindPotentialTargetBrain(brainCamera);
        _hucanCam.Priority = 0;
    }

    public void HucanCameraFlag()
    {
        if (_objCam.Priority != 100)
        {
            cameraFlag = !cameraFlag;
        }
    }
        // Update is called once per frame
    void Update()
    { 
        //���ݓ����Ă�Blend���擾
        var blend = brain.ActiveBlend;

        if (blend != null)
        {
            //1�Ńu�����h�I��
            if (blend.BlendWeight < 0.9 || _hucanCam.Priority == 100)
            {
                _hukanCamera = true;
                _playerMove.IsMove = false;
            }
            //�u���b�N��I��
            else if(_objCam.Priority == 100)
            { _playerMove.IsMove = false; }
            else { _playerMove.IsMove = true; _hukanCamera = false; }
        }


        if(cameraFlag) { _hucanCam.Priority = 100; }
        else { _hucanCam.Priority = 0; }
    }
}
