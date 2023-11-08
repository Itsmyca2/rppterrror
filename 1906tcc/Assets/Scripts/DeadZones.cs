using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZones : MonoBehaviour


{
    public GameObject player;
    public Transform pointI;
    public Transform pointII;
    public Transform pointIII;
    public Transform pointIV;
    public Transform pointV;
    public Transform pointVI;
    public Transform pointVII;
    public Transform pointVIII;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("dead0123"))
        {
            player.transform.position = pointI.transform.position;
        }
        if (other.gameObject.CompareTag("dead45678"))
        {
            player.transform.position = pointII.transform.position;
        }
        if (other.gameObject.CompareTag("dead9"))
        {
            player.transform.position = pointIII.transform.position;
        }
        if (other.gameObject.CompareTag("dead1011121314"))
        {
            player.transform.position = pointIV.transform.position;
        }
        if (other.gameObject.CompareTag("dead15161718"))
        {
            player.transform.position = pointV.transform.position;
        }
        if (other.gameObject.CompareTag("dead1920"))
        {
            player.transform.position = pointVI.transform.position;
        }
        if (other.gameObject.CompareTag("dead21222324"))
        {
            player.transform.position = pointVII.transform.position;
        }
        if (other.gameObject.CompareTag("dead25262728"))
        {
            player.transform.position = pointVIII.transform.position;
        }
    }
}
