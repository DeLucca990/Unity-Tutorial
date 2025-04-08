using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public int remainingCollectibles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingCollectibles = GameObject.FindGameObjectsWithTag("Coletavel").Length;
    }

    public void CollectibleCollected()
    {
        remainingCollectibles--;
        if (remainingCollectibles <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverScreen.Setup();
    }
}
