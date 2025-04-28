using UnityEngine;
public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 4f;  // Initial fall speed
    public static bool targetPlayer = false; // Target player flag
    private float speedIncreaseRate = 0.1f; // How much fall speed increases per second

    void Update()
    {
        // Increase fall speed over time
        fallSpeed += speedIncreaseRate * Time.deltaTime;

        // If targeting the player, move towards them
        if (targetPlayer)
        {
            Vector2 targetPosition = GameObject.FindWithTag("Player").transform.position;
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            transform.Translate(direction * fallSpeed * Time.deltaTime);
        }
        else
        {
            // Fall normally
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        }

        // Destroy object if it falls below the screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            other.GetComponent<PlayerHealth>().TakeDamage();
            Destroy(gameObject);
        }
    }

}
