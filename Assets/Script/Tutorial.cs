using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    bool WASDflag = false;
    bool JumpFlag = false;
    [SerializeField] GameObject _WASD = null;
    [SerializeField] GameObject _Jump = null;
    [SerializeField] GameObject _Drag = null;
    bool faze1flag = true;

    bool mouseDragFlag = false;
    bool mouseClickFlag = false;
    bool blockMoveFlag = false;
    bool faze2flag = true;

    [SerializeField] GameObject[] _Check = null;
    [SerializeField] GameObject[] _CheckBox = null;
    [SerializeField] GameObject[] _Panel = null;

    // Update is called once per frame
    void Update()
    {
        _WASD.SetActive(faze1flag);
        _Jump.SetActive(faze1flag);

        if (!WASDflag)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Debug.Log("QAAAAAAA");
                WASDflag = true;
                _Check[0].SetActive(true);
            }
        }

        if (!JumpFlag)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                JumpFlag = true;
                _Check[1].SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(WASDflag && JumpFlag && faze1flag)
        {
            for(int i = 0; i < 2; i++)
            {
                _Check[i].SetActive(false);
                _CheckBox[i].SetActive(false);
            }
            _Panel[0].SetActive(false);
            _Panel[1].SetActive(true);

            faze1flag = false;
            faze2flag = true;
            _Drag.SetActive(true);
            _CheckBox[2].SetActive(true);
        }
    }

}