using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{
    public Animator animator;
    public GameObject ponteI;
    public GameObject ponteII;
    public GameObject ponteIII;
    public GameObject ponteIV;
    public GameObject ponteV;
    public GameObject ponteVI;

    public bool alavancaI;
    public bool alavancaII;
    public bool alavancaIII;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("alavancaVirou", true);
        }

        else
        {
            animator.SetBool("alavancaVirou", false);
        }

        if (other.gameObject.CompareTag("Player") && alavancaI)
        {
            ponteI.SetActive(true);
            ponteII.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && alavancaII)
        {
            ponteIII.SetActive(true);
            ponteIV.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && alavancaIII)
        {
            ponteV.SetActive(true);
            ponteVI.SetActive(true);
        }
    }
}
