using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GolfClub : MonoBehaviour
{
    public TeenagerTalk teen;

    public GameObject enableOnBreak;
    public GameObject clubBottom;

    public bool brokenClub;
    private void Awake()
    {
        teen = FindObjectOfType<TeenagerTalk>();
        clubBottom.SetActive(true);
        brokenClub = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golf Ball") && !brokenClub)
        {
            Debug.Log("brokenclub");
            brokenClub = true;
            teen.BrokenClub();
            GetComponent<AudioSource>().Play();
            Instantiate(enableOnBreak, transform.position, quaternion.identity);
            clubBottom.SetActive(false);
            
        }
    }
}
