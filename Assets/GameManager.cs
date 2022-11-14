using UnityEngine;
using UnityEngine.SceneManagement;    // using��Y��Ȃ���

public class GameManager : MonoBehaviour
{

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