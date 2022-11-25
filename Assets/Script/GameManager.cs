using UnityEngine;
using UnityEngine.SceneManagement;    // using��Y��Ȃ���

public class GameManager : MonoBehaviour
{
    int moveCount = 0;
    [SerializeField] int maxMoveCount = 3;

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
        moveCount = 0;
    }

    public void MoveCount()
    {
        if (maxMoveCount <= moveCount) return;
        moveCount++;
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
}