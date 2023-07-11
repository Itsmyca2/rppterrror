using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InimigoUm : MonoBehaviour
{
    //public float inimigoVelocidade;

    #region Movimentação Jogador

    [SerializeField] private float velocidadeMovimento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private SpriteRenderer spriteRender;

    #endregion

     public Transform alvo;
     [SerializeField] private float raioVisao;
     [SerializeField] private LayerMask playerLayer;
     
     public int vida;
     public Transform barraDeVida;        //barra verde
     public GameObject barradeVidaObject; // objeto pai das barras
     
     private Vector3 escalaBarraVida; //tamanho da barra
     private float barraVidaPercentual;

     public float distanciaMaxAtaque;
     [SerializeField] private float intervaloAtaque;
     private float tempoEsperaProxAtaque;
     
     
     


// Start is called before the first frame update
    void Start()
    {
        escalaBarraVida = barraDeVida.localScale;
        barraVidaPercentual = escalaBarraVida.x / vida;
        this.tempoEsperaProxAtaque = this.intervaloAtaque;

    }

    // Update is called once per frame
    void Update()
    {
        //MovimentoInimigo();
        ProcurarJogador();
        if (this.alvo != null) //se tem um alvo
        {
            MovimentoInimigo();
            VerficarProximoAtaque();
        }
        else // se nao tiver alvo
        {
            PararMovimentacao();
        }
    }

    void UpdateBarraVida()
    {
        escalaBarraVida.x = barraVidaPercentual * vida;
        barraDeVida.localScale = escalaBarraVida;
    }
    void MovimentoInimigo()
    {
        //transform.Translate(Vector3.left * inimigoVelocidade * Time.deltaTime);

        Vector2 posicaoAlvo = this.alvo.position;
        posicaoAlvo.y = 0;
        Vector2 posicaoAtual = this.transform.position;
        posicaoAtual.y = 0;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= this.distanciaMinima)
        {
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;


            this.rigidBody2D.velocity = (this.velocidadeMovimento * direcao);

            if (this.rigidBody2D.velocity.x > 0)
            {
                this.spriteRender.flipX = true;
            }
            else if (this.rigidBody2D.velocity.x < 0)
            {
                this.spriteRender.flipX = false;
            }
            
        }
        else
        {
            PararMovimentacao();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
    }

    private void ProcurarJogador()
    {
        //Debug.Log("Procurando");
       Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, playerLayer );
       if (colisor != null)
       {
           //Debug.Log("Achei");
           this.alvo = colisor.transform;
       }
       else
       {
           this.alvo = null;
       }
    }

    private void PararMovimentacao()
    {
        this.rigidBody2D.velocity = Vector2.zero;
    }

    public void ReceberDano()
    {
        vida--;
        UpdateBarraVida();
        if (vida == 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void Atacar()
    {
        Personagem personagem = alvo.GetComponent<Personagem>();
        personagem.ReceberDano();
    }

    private void VerficarProximoAtaque()
    {
        Personagem personagem = alvo.GetComponent<Personagem>();
        if (personagem.Derrotado)
        {
            //vai interromper o resto do metodo
            return;
        }
        
        float distancia = Vector3.Distance(this.transform.position, alvo.position);
        if (distancia <= this.distanciaMaxAtaque)
        {
            this.tempoEsperaProxAtaque -= Time.deltaTime;
            if (tempoEsperaProxAtaque <= 0)
            {
                this.tempoEsperaProxAtaque = this.intervaloAtaque;
                Atacar();
            }
        }
    }
}
