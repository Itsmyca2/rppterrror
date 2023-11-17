using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    private AudioSource sommoeda;


    private void Awake()
    {
        sommoeda = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sommoeda.Play();
            other.gameObject.GetComponent<Personagem>().ColetarMoedas();
            Destroy(this.gameObject, 0.1f);
        }
    }
}
