using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderChefao : MonoBehaviour
{
    public float velocidadePoder;
    public bool left;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (left) MagiaDireita();
        else MagiaEsquerda();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Personagem>().ReceberDano();
            
            Destroy(this.gameObject);
        }
        

    }
    public void MagiaDireita()
    {
        //magiaSprite.flipX = false;
        transform.Translate(Vector3.right * velocidadePoder * Time.deltaTime);
        
    }

    public void MagiaEsquerda()
    {
        //magiaSprite.flipX = true;
        transform.Translate(Vector3.left * velocidadePoder * Time.deltaTime);
    }
    
    
}
