using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public bool hasKey = false;

    public int hp = 3;

    public TextMeshProUGUI hpText;

    public GameObject gameOverPanel;

    public GameObject damageText;

    public GameObject pausePanel;

    void Awake()
    {
        I = this;

        UpdateHP();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (damageText != null)
            damageText.SetActive(false);

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        bool isPaused = pausePanel.activeSelf;

        pausePanel.SetActive(!isPaused);

        if (!isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void GetKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(next);
    }

    public void TakeDamage()
    {
        hp--;

        UpdateHP();

        if (damageText != null)
        {
            StopAllCoroutines();
            StartCoroutine(ShowDamageText());
        }

        if (hp <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    void UpdateHP()
    {
        hpText.text = "HP: " + hp;
    }

    IEnumerator ShowDamageText()
    {
        damageText.SetActive(false);

        damageText.transform.localPosition = new Vector3(0, 1.5f, 0);

        damageText.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        damageText.SetActive(false);
    }
}