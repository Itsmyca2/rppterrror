using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroMovimento : MonoBehaviour
{
    public float velocidadeTiro;
    public int darDano;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TirosMovimentos();
    }

    private void TirosMovimentos()
    {
        transform.Translate(Vector3.left * velocidadeTiro * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("chegou");
            
            other.gameObject.GetComponent<Personagem>().ReceberDano();
            Destroy(this.gameObject);
        }
        

    }
}