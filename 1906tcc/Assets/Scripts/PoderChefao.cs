using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderChefao : MonoBehaviour
{
    public float velocidadePoder;
    

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
        transform.Translate(Vector3.left * velocidadePoder* Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Personagem>(). ColidindoComMagia();
            other.gameObject.GetComponent<Personagem>().ReceberDano();
            Destroy(this.gameObject);
        }
        

    }
    
    
}
