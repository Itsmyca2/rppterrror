using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPowerUp : MonoBehaviour
{
    private AudioSource somPower;
    
    // Start is called before the first frame update
    private void Awake()
    {
        somPower = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            somPower.Play();
        }
    }
}
