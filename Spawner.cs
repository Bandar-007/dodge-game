using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float spawnInterval = 1.5f;
    private float timer;
    private float speedIncreaseTime = 10f; // Time interval to increase speed
    private float nextSpeedIncreaseTime = 10f; // Track when to increase fall speed
    private float speedMultiplier = 1f; // Global speed multiplier
    void Update()
    {
        timer += Time.deltaTime;
        // Spawn objects at set intervals
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
        // Increase fall speed over time
        if (Time.time >= nextSpeedIncreaseTime)
        {
            speedMultiplier += 0.2f; // Increase speed multiplier
            nextSpeedIncreaseTime = Time.time + speedIncreaseTime; // Reset timer for next increase
        }
    }
    void SpawnObject()
    {
        if (fallingObjectPrefab == null)
        {
            Debug.LogError("❌ Falling Object Prefab is missing!");
            return;
        }
        GameObject player = GameObject.FindWithTag("Player");
        float playerX = player != null ? player.transform.position.x : 0f;
        // Prevent spawning too close to the player
        float randomX = Random.Range(-9f, 9f);
        Vector2 spawnPosition = new Vector2(randomX, 6f);
        GameObject obj = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);

        // Apply speed multiplier to the falling object
        obj.GetComponent<FallingObject>().fallSpeed *= speedMultiplier;
    }
}




