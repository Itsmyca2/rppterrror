    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaJogador : MonoBehaviour
{
    public int velocidadeMagia;
    public GameObject magia;
    public int tempoDestruir;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(magia, tempoDestruir);
    }

    // Update is called once per frame
    void Update()
    {
        TirosMovimentos();
    }

    private void TirosMovimentos()
    {
        transform.Translate(Vector3.right * velocidadeMagia * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {

            other.gameObject.GetComponent<InimigoUm>().ReceberDano();
            Destroy(this.gameObject);
        }
        

    }
}
