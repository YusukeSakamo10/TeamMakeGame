using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    bool WASDflag = false;
    bool JumpFlag = false;
    [SerializeField] GameObject _WASDText = null;
    [SerializeField] GameObject _JumpText = null;
    [SerializeField] GameObject _DragText = null;
    [SerializeField] GameObject _ClickText = null;
    [SerializeField] GameObject _BlockMoveText = null;
    [SerializeField] GameObject _GoalMoveText = null;
    [SerializeField] GameObject _NokorikaisuText = null;

    bool faze1flag = true;
    bool faze2flag = false;
    bool faze3flag = false;
    bool faze4flag = false;
    bool faze5flag = false;

    [SerializeField] GameObject[] _Check = null;
    [SerializeField] GameObject[] _CheckBox = null;
    [SerializeField] GameObject[] _Panel = null;

    PlayerMove _player;
    [SerializeField] GameObject[] _Object = null;
    [SerializeField] int time = 20;
    private void Start()
    {
        PlayerMove p = GameObject.Find("player").GetComponent<PlayerMove>();
        if (p != null) _player = p.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        _WASDText.SetActive(faze1flag);
        _JumpText.SetActive(faze1flag);

        if (!WASDflag)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Debug.Log("QAAAAAAA");
                WASDflag = true;
                _Check[1].SetActive(true);
            }
        }

        if (!JumpFlag)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                JumpFlag = true;
                _Check[2].SetActive(true);
            }
        }


        if(faze2flag && Input.GetMouseButtonDown(1))
        {
            _Check[2].SetActive(true);
        }

        if(faze2flag && _player.transform.position.z < -18)
        {
            faze2flag = false;
            faze3flag = true;
            _Check[2].SetActive(false);
            _DragText.SetActive(false);
            _ClickText.SetActive(true);
        }

        if(faze3flag && !_player.IsMove)
        {
            faze3flag = false;
            faze4flag = true;
            _Check[2].SetActive(true);
        }

        if (faze4flag)
        {
            if (time > 0) 
            {
                time--;
            }
            if(time <= 0)
            {
                faze4flag = false;
                faze5flag = true;
                _ClickText.SetActive(false);
                _Check[2].SetActive(false);
                _CheckBox[2].SetActive(false);
                _BlockMoveText.SetActive(true);
                _Panel[0].SetActive(true);
                _Panel[1].SetActive(false);
                _Panel[2].SetActive(true);
                _NokorikaisuText.SetActive(true);
            }
        }
        if(faze5flag && _player.IsMove)
        {
            _NokorikaisuText.SetActive(false);
            _BlockMoveText.SetActive(false);
            _Panel[2].SetActive(false);
            _GoalMoveText.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(WASDflag && JumpFlag && faze1flag)
        {
            for(int i = 1; i < 3; i++)
            {
                _Check[i].SetActive(false);
                _CheckBox[i].SetActive(false);
            }

            for(int i = 0; i < 6;i++)
            {
                _Object[i].SetActive(true);
            }

            _Panel[0].SetActive(false);
            _Panel[1].SetActive(true);

            faze1flag = false;
            faze2flag = true;
            _DragText.SetActive(true);
            _CheckBox[2].SetActive(true);
        }
    }

}