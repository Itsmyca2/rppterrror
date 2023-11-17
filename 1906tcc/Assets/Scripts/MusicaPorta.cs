using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicaPorta : MonoBehaviour
{
    private AudioSource somPalacio;
    // Start is called before the first frame update
    
    private void Awake()
    {
        somPalacio = GetComponent<AudioSource>();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            somPalacio.Play();
        }
        
    }
    
}
