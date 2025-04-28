using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float invincibilityDuration = 1f;
    public Image[] hearts; // Assign heart images in the Inspector
    public GameObject gameOverPanel; // Assign your Game Over UI panel
    private int currentHealth;
    private bool isInvincible = false;
    private SpriteRenderer sprite;
    void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        UpdateHearts();
        gameOverPanel.SetActive(false);
    }
    public void TakeDamage()
    {
        if (isInvincible) return;
        currentHealth--;
        UpdateHearts();
        StartCoroutine(FlashEffect());
        StartCoroutine(InvincibilityTimer());
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        Destroy(gameObject); // Destroy player

        // Destroy all falling objects
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("FallingObject");
        foreach (GameObject obj in obstacles)
        {
            Destroy(obj);
        }
    }
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }
    System.Collections.IEnumerator FlashEffect()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    System.Collections.IEnumerator InvincibilityTimer()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}
