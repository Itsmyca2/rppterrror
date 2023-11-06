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
    
    public Transform localdeidaSala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && portamasmorra)
        {
            player.transform.position = localdeidaI.transform.position;
        }

        if (other.gameObject.CompareTag("Player") && portasala)
        {
            player.transform.position = localdeidaSala.transform.position;
        }
    }
}
