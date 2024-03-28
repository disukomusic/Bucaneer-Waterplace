using System.Collections;
using UnityEngine;

public class GolfHole : MonoBehaviour
{
    public GameObject flag;
    public Transform flagStart;
    public Transform flagEnd;
    public AudioSource InTheHole;

    private bool flagRaised = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golf Ball") && !flagRaised)
        {
            Destroy(other.gameObject);
            InTheHole.Play();
            StartCoroutine(RaiseFlag());
            flagRaised = true;
        }
    }

    IEnumerator RaiseFlag()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = flagStart.position;
        Vector3 targetPosition = flagEnd.position;

        while (elapsedTime < 3f)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 3f);
            flag.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }

        flag.transform.position = targetPosition;
    }
}