using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float baseSpeed = 3f;
    public float speedIncreasePerItem = 0.2f;

    private Transform player;
    private GameController gameController;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (player != null && gameController != null)
        {
            float currentSpeed = baseSpeed + gameController.CollectedItems * speedIncreasePerItem;

            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * currentSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameController != null)
                gameController.GameOver();
        }
    }
}
