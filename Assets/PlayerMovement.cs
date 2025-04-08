using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    private Rigidbody2D rb;
    AudioSource audio;
    public float speed; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movrHorizontal = Input.GetAxis("Horizontal");
        float movrVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(movrHorizontal, movrVertical);

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            audio.Play();
            Destroy(other.gameObject);

            GameController gc = FindObjectOfType<GameController>();
            if (gc != null)
            {
                gc.CollectibleCollected();
            }
        }
    }
}
