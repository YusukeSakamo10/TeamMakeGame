using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;    // usingを忘れないで
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int moveCount = 0;
    [SerializeField] int maxMoveCount = 3;

    [Tooltip("jumpした時に呼び出す処理")]
    [SerializeField] UnityEvent _onJump = null;

    //[Tooltip("残り移動回数の初期値")]
    //[SerializeField] int _initialMove = 5;

    [Tooltip("残り移動回数を表示するための Text (UI)")]
    [SerializeField] Text _moveText = null;
    /// <summary>残り移動回数を表示するための GameObject</summary>
    GameObject _moveObject;


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
        moveCount =0;

        _moveObject = GameObject.Find("MoveText");
        _moveText = _moveObject.GetComponent<Text>();
       _moveText.text = string.Format("{0:000}", maxMoveCount);
    }

    public void MoveCount()
    {
        if (maxMoveCount <= moveCount) return;
        moveCount++;

        int tmp = maxMoveCount - moveCount;
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
}