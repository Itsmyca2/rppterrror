using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InimigoUm : MonoBehaviour
{
    //public float inimigoVelocidade;

    #region Movimentação Jogador

    [SerializeField] private float velocidadeMovimento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private SpriteRenderer spriteRender;

    #endregion

     private Transform alvo;
     [SerializeField] private float raioVisao;
     [SerializeField] private LayerMask playerLayer;
     


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MovimentoInimigo();
        ProcurarJogador();
        if (this.alvo != null) //se tem um alvo
        {
            MovimentoInimigo();
        }
        else // se nao tiver alvo
        {
            PararMovimentacao();
        }
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
        Debug.Log("Procurando");
       Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, playerLayer );
       if (colisor != null)
       {
           Debug.Log("Achei");
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
}
