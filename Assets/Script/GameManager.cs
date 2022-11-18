using UnityEngine;
using UnityEngine.SceneManagement;    // usingを忘れないで

public class GameManager : MonoBehaviour
{

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