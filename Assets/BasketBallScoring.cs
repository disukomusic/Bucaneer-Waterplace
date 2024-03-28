using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallScoring : MonoBehaviour
{
    public AudioSource basketAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            Debug.Log("basket");
            basketAudio.Play();
        }
    }
}
