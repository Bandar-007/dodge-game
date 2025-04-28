using UnityEngine;

public class PlayerMovementTracker : MonoBehaviour
{
    public float timeThreshold = 3f; // Time before falling objects start targeting
    private float timeStill = 0f;
    private Vector3 lastPosition;

    void Update()
    {
        // If player hasn't moved
        if (transform.position == lastPosition)
        {
            timeStill += Time.deltaTime;
        }
        else
        {
            timeStill = 0f; // Reset if the player moves
        }

        lastPosition = transform.position;

        if (timeStill >= timeThreshold)
        {
            // Notify that the player is stationary for too long
            FallingObject.targetPlayer = true; // Enable targeting behavior in FallingObject
        }
        else
        {
            FallingObject.targetPlayer = false; // Disable targeting behavior
        }
    }
}
