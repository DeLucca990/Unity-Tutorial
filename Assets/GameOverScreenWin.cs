using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenWin : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
