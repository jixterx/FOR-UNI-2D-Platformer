using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public bool hasKey = false;

    void Awake()
    {
        I = this; // <-- ÃËÀÂÍÎÅ: ÷òîáû íå áûë null
    }

    public void GetKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(next);
    }
}
