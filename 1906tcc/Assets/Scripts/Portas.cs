using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{

    public GameObject player;
    public Transform localdeidaI;

    public Transform localPalacio;
    public bool portamasmorra;
    public bool portasala;
    public bool portaPalacio;
    public Animator animator;

    public float contador;

    private AudioSource somPalacio;
    private AudioSource somFloresta;
    
    public Transform localdeidaSala;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        somFloresta = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && portamasmorra)
        {
            contador--;
            animator.SetBool("porta aberta", true);
            if (contador <= 0f)
            {
                player.transform.position = localdeidaI.transform.position;
            }
            
        }

        if (other.gameObject.CompareTag("Player") && portasala)
        {
            player.transform.position = localdeidaSala.transform.position;
        }
        if (other.gameObject.CompareTag("Player") && portaPalacio)
        {
            player.transform.position = localPalacio.transform.position;
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && portaPalacio)
        {
            somFloresta.Stop();
        }
    }
}
