using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TeenagerTalk : MonoBehaviour
{
    public AudioSource teenVoice;
    public GameObject clubPrefab;
    public Transform clubSpawnPoint;
    
    
    public AudioClip greeting;
    public AudioClip minigolf;
    public AudioClip brokenclub;
    public AudioClip jumpingpillow;

    public bool hasDoneGreeting;
    public bool hasDoneMiniGolf;
    public bool hasDoneBrokenClub;
    public bool hasDoneJumpingPillow;


    public void Greeting()
    {
        if (!teenVoice.isPlaying && !hasDoneGreeting)
        {
            hasDoneGreeting = true;
            teenVoice.PlayOneShot(greeting);

        }
    }
    
    public void MiniGolf()
    {
        if (!teenVoice.isPlaying && !hasDoneMiniGolf)
        {
            hasDoneMiniGolf = true;
            teenVoice.PlayOneShot(minigolf);
            StartCoroutine(WaitForDepositRoutine());
        }
    }
    
    public void BrokenClub()
    {
        if (!teenVoice.isPlaying && !hasDoneBrokenClub)
        {            
            hasDoneBrokenClub = true;
            teenVoice.PlayOneShot(brokenclub);
        }
    }
    
    public void JumpingPillow()
    {
        if (!teenVoice.isPlaying && !hasDoneJumpingPillow)
        {
            hasDoneJumpingPillow = true;
            teenVoice.PlayOneShot(jumpingpillow);
        }
    }

    public void SpawnClub()
    {
        Instantiate(clubPrefab, clubSpawnPoint.position, Quaternion.identity);
    }

    IEnumerator WaitForDepositRoutine()
    {
        yield return new WaitForSeconds(37f);
        SpawnClub();
        SpawnClub();

    }
}
