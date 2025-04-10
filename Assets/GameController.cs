using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public GameOverScreenWin gameOverScreenWin;
    public UIController uiController;
    public int remainingCollectibles;

    private float timer = 5f;
    private int totalCollectibles;
    private int collectedItems = 0;

    public int CollectedItems => collectedItems;

    void Start()
    {
        Time.timeScale = 1f;
        remainingCollectibles = GameObject.FindGameObjectsWithTag("Coletavel").Length;
        totalCollectibles = remainingCollectibles;

        uiController.UpdateCollected(collectedItems, totalCollectibles);
        uiController.UpdateTimer(timer);
    }

    void Update()
    {
        if (remainingCollectibles > 0)
        {
            timer -= Time.deltaTime;
            uiController.UpdateTimer(timer);

            if (timer <= 0)
            {
                GameOver();
            }
        }
    }

    public void CollectibleCollected()
    {
        remainingCollectibles--;
        collectedItems++;
        timer += 0.75f;

        uiController.UpdateCollected(collectedItems, totalCollectibles);
        uiController.UpdateTimer(timer);

        if (remainingCollectibles <= 0)
        {
            GameOverWin();
        }
    }

    public void GameOverWin()
    {
        gameOverScreenWin.Setup();
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        gameOverScreen.Setup();
        Time.timeScale = 0f;
    }
}
