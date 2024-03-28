using UnityEngine;

public class PitchingBall : MonoBehaviour
{
    // Variable to store the lifetime of the ball
    public float lifetime = 10f;

    void Awake()
    {
        // Invoke the function to destroy the ball after 'lifetime' seconds
        Invoke("DestroyBall", lifetime);
    }

    void DestroyBall()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}