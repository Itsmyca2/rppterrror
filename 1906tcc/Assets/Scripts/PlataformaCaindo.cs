using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaindo : MonoBehaviour
{
    private Rigidbody2D rb;
    private float delayqueda = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator QuedaPlataforma()
    {
        yield return new WaitForSeconds(0.2f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, delayqueda);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(QuedaPlataforma());
        }
    }
}
