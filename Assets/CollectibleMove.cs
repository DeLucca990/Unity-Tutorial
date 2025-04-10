using UnityEngine;

public class ColetavelMover : MonoBehaviour
{
    private Vector2 direction;
    private float speed;

    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
        speed = Random.Range(0.5f, 6.0f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f || pos.x > 1f) direction.x *= -1;
        if (pos.y < 0f || pos.y > 1f) direction.y *= -1;
    }
}