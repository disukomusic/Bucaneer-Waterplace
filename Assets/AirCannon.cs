using System;
using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR.Manipulation;
using UnityEngine;

public class AirCannon : MonoBehaviour
{
    public UxrGrabbableObject grabber;
    public GameObject cannonBall;
    public Transform ballSpawnPos;
    public ParticleSystem shootEffect;

    public AudioSource shootSound;
    private void Update()
    {
        
        bool wasPressed = UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Trigger);

        if (grabber.IsBeingGrabbed && wasPressed)
        {
            ShootBall();
        }
    }


    public void ShootBall()
    {
        shootEffect.Play();
        shootSound.Play();
        GameObject ball = Instantiate(cannonBall, ballSpawnPos.position, transform.localRotation);
        ball.GetComponent<Rigidbody>().AddForce(ballSpawnPos.up * 12f, ForceMode.Impulse); // Adjusted force direction
    }
}
