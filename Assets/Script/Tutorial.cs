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
    [SerializeField] GameObject _BlackPanel = null;


    PlayerMove _player;
    [SerializeField] GameObject[] _Object = null;
    [SerializeField] int changeTime = 20;
    int blackTimer = 1;

    [SerializeField] GameObject _particle;
    private void Start()
    {
        PlayerMove p = GameObject.Find("Majo").GetComponent<PlayerMove>();
        if (p != null) _player = p.GetComponent<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        //ステージギミックの初期化
        if (blackTimer > 0) 
        {
            for (int i = 0; i < 6; i++)
            {
                _Object[i].SetActive(false);
            }
            _BlackPanel.SetActive(false);
            blackTimer--; 
        }

        //１フェーズが終わったらテキストを切り替える
        _WASDText.SetActive(faze1flag);
        _JumpText.SetActive(faze1flag);

        //WASDを押すまでこの処理に入る
        if (!WASDflag)
        {
            //押したらチェックをつける
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                WASDflag = true;
                _Check[1].SetActive(true);
            }
        }

        //ジャンプするまで
        if (!JumpFlag)
        {
            //ジャンプしたらチェックをつける
            if (Input.GetKey(KeyCode.Space))
            {
                JumpFlag = true;
                _Check[2].SetActive(true);
            }
        }
        if (_Object[0].activeSelf == true)
        {
            _particle.SetActive(false);
        }

        //フェーズ２の時左クリックを押したらチェックをつける
        if(faze2flag && Input.GetMouseButtonDown(1))
        {
            _Check[2].SetActive(true);
        }

        //フェーズ２の時プレイヤーの位置がブロックに近づいたとき
        if (faze2flag && _player.transform.position.z < 2.5)
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
            if (changeTime > 0) 
            {
                changeTime--;
            }
            if(changeTime <= 0)
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

    //パーティクル（チュートリアルマネージャーに触れたら）
    private void OnTriggerEnter(Collider other)
    {
        //フェーズ１のフラグが全部立っていたら
        if(WASDflag && JumpFlag && faze1flag)
        {
            //チェックボックスの切り替え
            for(int i = 1; i < 3; i++)
            {
                _Check[i].SetActive(false);
                _CheckBox[i].SetActive(false);
            }

            //オブジェクトを出現させる
            for(int i = 0; i < 6;i++)
            {
                _Object[i].SetActive(true);
            }

            //緑のパネルの切り替え
            _Panel[0].SetActive(false);
            _Panel[1].SetActive(true);

            //フェーズの切り替え
            faze1flag = false;
            faze2flag = true;
            //フェーズ２のテキスト表示
            _DragText.SetActive(true);
            _CheckBox[2].SetActive(true);
        }
    }

}