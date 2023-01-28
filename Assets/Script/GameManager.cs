using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;    // using��Y��Ȃ���
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    int moveCount = 0;
    [SerializeField] int maxMoveCount = 3;

    [Tooltip("jump�������ɌĂяo������")]
    [SerializeField] UnityEvent _onJump = null;

    [Tooltip("button�����������ɌĂяo������")]
    [SerializeField] UnityEvent _onShoot = null;

    //[Tooltip("�c��ړ��񐔂̏����l")]
    //[SerializeField] int _initialMove = 5;

    [Tooltip("�c��ړ��񐔂�\�����邽�߂� Text (UI)")]
    [SerializeField] Text _moveText = null;
    /// <summary>�c��ړ��񐔂�\�����邽�߂� GameObject</summary>
    GameObject _moveObject;

    static bool[] _clearFlag = {false,false,false,false,false };
    [SerializeField] string stageName = "";

    [SerializeField] CinemachineVirtualCamera[] _vCam = {null, null, null, null, null };
    [SerializeField] GameObject[] Light = { null, null, null, null, null };
    int cameraTime = 60;
    int cameraMaxTime = 60;

    public int MoveCountValue
    {
        get { return moveCount; }
        set { moveCount = value; }
    }

    public int MaxMoveCount
    {
        get { return maxMoveCount; }
        set { maxMoveCount = value; }
    }

    private void Start()
    {
        if (stageName == "stageSelect")
        {
            cameraTime = cameraMaxTime;
            for (int i = 0; i < 5; i++)
            {
                if (_clearFlag[i])
                {
                    _vCam[i].Priority = 100;
                }
            }
        }
        moveCount = 0;

        _moveObject = GameObject.Find("MoveText");
        _moveText = _moveObject.GetComponent<Text>();
       _moveText.text = string.Format("{0:000}", maxMoveCount);
    }

    private void Update()
    {
        if (stageName == "stageSelect")
        {
            if (cameraTime > 0) { cameraTime--; }
            for (int i = 0; i < 5; i++)
            {
                if (cameraTime <= 0)
                {
                    Light[i].SetActive(true);
                    _vCam[i].Priority = 0;
                    _clearFlag[i] = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _onJump.Invoke();
        }

        if (Input.GetButtonDown("Fire1"))
        { 
            _onShoot.Invoke();
        }

    }


    public void MoveCount()
    {
        if (maxMoveCount <= moveCount) return;
        moveCount++;

        int tmp = maxMoveCount - moveCount;
        if (tmp < 3) _moveText.color = Color.red;
        else _moveText.color = Color.white;
        _moveText.text = tmp.ToString("000");

    }

    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    public void ChangeScene(string nextScene)  // �V�������\�b�h�ǉ�
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ClearFlag(string clear)
    {
        if (clear == "turtorial") { _clearFlag[0] = true; }
        if (clear == "stage1") { _clearFlag[1] = true; }
        if (clear == "stage2") { _clearFlag[2] = true; }
        if (clear == "stage3") { _clearFlag[3] = true; }
        if (clear == "stage4") { _clearFlag[4] = true; }
    }
}