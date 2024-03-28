using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpingPillow : MonoBehaviour
{
    public UnityEvent jump;
    public UnityEvent pop;

    public bool hasPopped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPopped)
        {
            hasPopped = true;
            jump.Invoke();
            Invoke("PopFunction", 3f);
        }
    }

    public void PopFunction()
    {
        pop.Invoke();
    }
}
