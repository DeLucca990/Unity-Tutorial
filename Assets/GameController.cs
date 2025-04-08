using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public UIController uiController;
    public int remainingCollectibles;

    private float timer = 5f;
    private int totalCollectibles;
    private int collectedItems = 0;

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
        timer += 1f;

        uiController.UpdateCollected(collectedItems, totalCollectibles);
        uiController.UpdateTimer(timer);

        if (remainingCollectibles <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverScreen.Setup();
        Time.timeScale = 0f;
    }
}
