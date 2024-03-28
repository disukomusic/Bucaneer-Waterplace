using UnityEngine;

public class PitchingMachine : MonoBehaviour
{
    public AudioSource pitchingMachineSound;

    public AudioSource pitchingMachineThrow;
    public GameObject ballPrefab;
    public Transform ballSpawn;
    public Animator arm;
    public bool pitching = false;

    private float pitchTimer;
    public float pitchInterval = 1.2f; // Time interval between pitches in seconds

    private void Start()
    {
        pitchTimer = pitchInterval; // Start with full interval to pitch immediately on StartPitching
    }

    private void Update()
    {
        if (pitching)
        {
            pitchTimer -= Time.deltaTime;
            if (pitchTimer <= 0f)
            {
                Pitch();
                pitchTimer = pitchInterval; // Reset timer
            }
        }
    }

    public void Pitch()
    {
        pitchingMachineThrow.Play();
        GameObject ball = Instantiate(ballPrefab, ballSpawn.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10f, ForceMode.Impulse); // Adjusted force direction
    }

    public void StartPitching()
    {
        arm.SetBool("pitch", true);
        pitchingMachineSound.Play();
        pitching = true;
        pitchTimer = 0f; // Forces immediate pitch on the next Update cycle
    }

    public void StopPitching()
    {
        arm.SetBool("pitch", false);
        pitchingMachineSound.Stop();
        pitching = false;
    }
}