    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaJogador : MonoBehaviour
{
    public int velocidadeMagia;
    public GameObject magia;
    public int tempoDestruir;
    public SpriteRenderer flipPersonagem;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(magia, tempoDestruir);
    }

    // Update is called once per frame
    void Update()
    {
        //TirosMovimentos();
        
    }

   /* private void TirosMovimentos()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            flipPersonagem.flipX = false;
            transform.Translate(Vector3.right * velocidadeMagia * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            flipPersonagem.flipX = true;
            transform.Translate(Vector3.left * velocidadeMagia * Time.deltaTime);
        }
        
        
    }
   */

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {

            other.gameObject.GetComponent<InimigoUm>().ReceberDano();
            Destroy(this.gameObject);
        }
        

    }

    public void MagiaDireita()
    {
        transform.Translate(Vector3.right * velocidadeMagia * Time.deltaTime);
    }

    public void MagiaEsquerda()
    {
        transform.Translate(Vector3.left * velocidadeMagia * Time.deltaTime);
    }
}
