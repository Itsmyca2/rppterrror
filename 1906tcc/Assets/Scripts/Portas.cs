using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{

    public GameObject player;
    public Transform localdeidaI;
    public bool portamasmorra;
    public bool portasala;
    public Animator animator;

    public float contador;
    
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
    }
}
