using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
     
     
     public GameObject flecha;
     public Transform pontoFlecha;
     public bool arqueiro;
     public float tempoTiros;
     public float atualTempTiros;

     public bool chefao;
     public Transform pontoPoder;
     public GameObject poder;

     public DropItens dropScript;

     public AniEnemyI inimigo1anim;
     public AniEnemyII inimigo2Anim;
     public AniEnemyIII inimigo3Anim;

     public bool inimigoI;
     public bool inimigoII;
     public bool inimigoIII;
     


// Start is called before the first frame update
    void Start()
    {
        escalaBarraVida = barraDeVida.localScale;
        barraVidaPercentual = escalaBarraVida.x / vida;
        this.tempoEsperaProxAtaque = this.intervaloAtaque;
        dropScript = GetComponent<DropItens>();

    }

    // Update is called once per frame
    void Update()
    {
        //MovimentoInimigo();
        ProcurarJogador();
        /*if (!arqueiro)
        {
            if (this.alvo != null) //se tem um alvo
            {
                MovimentoInimigo();
                VerficarProximoAtaque();
            }
            else // se nao tiver alvo
            {
                PararMovimentacao();
            }
        }*/

        if (arqueiro)
        {
            TiroArqueiro();
        }

        if (chefao)
        {
            PoderChefao();
        }

        if (inimigoII)
        {
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

        if (inimigoIII)
        {
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
        
        
    }

    void UpdateBarraVida()
    {
        escalaBarraVida.x = barraVidaPercentual * vida;
        barraDeVida.localScale = escalaBarraVida;
    }
    void MovimentoInimigo()
    {

        if (inimigoII)
        {
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
                inimigo2Anim.InimigoII("WalkingInimigo2");
               // Debug.Log("andando");


                if (this.rigidBody2D.velocity.x > 0)
                {
                    this.spriteRender.flipX = true;
                }
                else if (this.rigidBody2D.velocity.x < 0)
                {
                    this.spriteRender.flipX = false;
                }
            }
        }

        if (inimigoIII)
        {
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
                inimigo3Anim.InimigoIII("WalkInimigo3");


                if (this.rigidBody2D.velocity.x > 0)
                {
                    this.spriteRender.flipX = true;
                }
                else if (this.rigidBody2D.velocity.x < 0)
                {
                    this.spriteRender.flipX = false;
                }
            }
        }
        else
        {
            //PararMovimentacao();
            //inimigo2Anim.InimigoII("IdleInimigo2");
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
        
        if (inimigoII)
        {
            inimigo2Anim.InimigoII("IdleInimigo2");
            this.rigidBody2D.velocity = Vector2.zero;
        }

        if (inimigoIII)
        {
            inimigo3Anim.InimigoIII("IdleInimigo3");
            this.rigidBody2D.velocity = Vector2.zero;
        }
        
    }

    public void ReceberDano()
    {
        vida--;
        bool pocaoforcaativada = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>().tacompocaoforca;

        if (pocaoforcaativada)
        {
            vida--;
        }

        if (gameObject.CompareTag("magia"))
        {
            vida -= 2;
        }

        UpdateBarraVida();
        if (vida <= 0)
        {
            if (vida <= 0 && arqueiro)
            {
                GameObject.Destroy(this.gameObject);
                dropScript.Drop();
            }
            if (vida <= 0 && chefao)
            {
                SceneManager.LoadScene("Vitoria");
                GameObject.Destroy(this.gameObject);
                dropScript.Drop();
                
            }

            if (vida <= 0 && inimigoII)
            {
                inimigo2Anim.InimigoII("DeadInimigo2");
                GameObject.Destroy(this.gameObject,0.5f);
                dropScript.Drop();
               
            }

            if (vida <= 0 && inimigoIII)
            {
                inimigo3Anim.InimigoIII("DeadInimigo3");
                GameObject.Destroy(this.gameObject, 0.5f);
                dropScript.Drop();
            }
        }
    }

    private void Atacar()
    {
        Personagem personagem = alvo.GetComponent<Personagem>();
        personagem.ReceberDano();
        if (inimigoII)
        {
            inimigo2Anim.InimigoII("AttackInimigo2");
        }

        if (inimigoIII)
        {
            inimigo3Anim.InimigoIII("AttackInimigo3");
        }
        
        
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

    public void TiroArqueiro()
    {
        atualTempTiros -= Time.deltaTime;
        if (atualTempTiros <= 0)
        {
            
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(flecha, pontoFlecha.position, rotation);
                atualTempTiros = tempoTiros;
                
        }
    }

    public void PoderChefao()
    {
        atualTempTiros -= Time.deltaTime;
        if (atualTempTiros <= 0)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(poder, pontoPoder.position, rotation);
            atualTempTiros = tempoTiros;
        }

        velocidadeMovimento = 1.5f;
    }
    
    
    
}
