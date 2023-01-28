using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;    // usingを忘れないで
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    int moveCount = 0;
    [SerializeField] int maxMoveCount = 3;

    [Tooltip("jumpした時に呼び出す処理")]
    [SerializeField] UnityEvent _onJump = null;

    [Tooltip("buttonを押した時に呼び出す処理")]
    [SerializeField] UnityEvent _onShoot = null;

    //[Tooltip("残り移動回数の初期値")]
    //[SerializeField] int _initialMove = 5;

    [Tooltip("残り移動回数を表示するための Text (UI)")]
    [SerializeField] Text _moveText = null;
    /// <summary>残り移動回数を表示するための GameObject</summary>
    GameObject _moveObject;

    static bool[] _clearFlag = {false,false,false,false,false };
    [SerializeField] string stageName = "";
    static bool[] lightFlag = { false,false,false,false,false };
    static string stageClearName;

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
            
            if(stageClearName == "turtorial"){_vCam[0].Priority = 100;}
            if (stageClearName == "stage1") { _vCam[1].Priority = 100; }
            if (stageClearName == "stage2") { _vCam[2].Priority = 100; }
            if (stageClearName == "stage3") { _vCam[3].Priority = 100; }
            if (stageClearName == "stage4") { _vCam[4].Priority = 100; }
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
                if (_clearFlag[i])
                {
                    if (cameraTime <= 0)
                    {
                        Light[i].SetActive(true);
                        _vCam[i].Priority = 0;
                    }
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

    public void ChangeScene(string nextScene)  // 新しくメソッド追加
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ClearFlag(string clear)
    {
        if (clear == "turtorial") { _clearFlag[0] = true; stageClearName = "turtorial"; }
        if (clear == "stage1") { _clearFlag[1] = true; stageClearName = "stage1"; }
        if (clear == "stage2") { _clearFlag[2] = true; stageClearName = "stage2"; }
        if (clear == "stage3") { _clearFlag[3] = true; stageClearName = "stage3"; }
        if (clear == "stage4") { _clearFlag[4] = true; stageClearName = "stage4"; }
    }
}