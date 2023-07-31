using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Personagem : MonoBehaviour
{
    //private GameObject lugarataque = GameObject.FindWithTag("lugarataque");
    
    public int velocidade;
    public float forcaPulo;
    private Rigidbody2D rig;
    
    
    public int vidaJogador;
    public Slider barraVidaJogador;
    

    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEChao;
    private SpriteRenderer sprite;
    private Animator playerAnim;

    [Header("Lugar do Ataque")] 
    public Transform attackCheck;
    private float attackCheckX;

    public float raioAtaque;
    public LayerMask layerEnemy;
    float tempoProximoAtaque;
    private float tempoAtaque;



    // Start is called before the first frame update
    void Start()
    {
        
        playerAnim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        attackCheckX = attackCheck.localPosition.x;

        barraVidaJogador.maxValue = vidaJogador;
        barraVidaJogador.value = vidaJogador;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        DetectarChao();
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontalMovimento = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(horizontalMovimento * velocidade, rig.velocity.y);
       
        
        
        if (horizontalMovimento > 0)
        {
            playerAnim.SetBool("Walk", true );
           //playerAnim.SetBool("Attack", false);
            sprite.flipX = false;
             attackCheck.localPosition = new Vector2 (attackCheckX, attackCheck.localPosition.y);
        }

        else if (horizontalMovimento < 0)
        {
            playerAnim.SetBool("Walk", true );
           //playerAnim.SetBool("Attack", false);
            sprite.flipX = true;
            attackCheck.localPosition = new Vector2 (-attackCheckX, attackCheck.localPosition.y);
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && taNoChao == true)
        {
            playerAnim.SetBool("Jump", true);
            playerAnim.SetBool("Attack", false);
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);

        }
        taNoChao = true;
    }

    void DetectarChao()
    {
        //playerAnim.SetBool("Jump", false);
        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEChao);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(detectaChao.position,0.2f);
        Gizmos.DrawSphere(attackCheck.position, raioAtaque);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            playerAnim.SetBool("Jump", false);
        }
    }

    private void Attack()
    {
        tempoAtaque -= Time.deltaTime;
        
       if (tempoAtaque <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerAnim.SetTrigger("Attack");
                tempoAtaque = 0.2f;
                PlayerAttack();
            }
            else
            {
                
            }
        }
        
        
        {
            
        }


    }

    void PlayerAttack()
    {
        Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll(attackCheck.position, raioAtaque, layerEnemy);
        
        for (int i = 0; i < enemiesAttack.Length; i++)
        {
            enemiesAttack [i].SendMessage("ReceberDano");
            
        }
    }

     public void ReceberDano()
    {
        vidaJogador--;
        barraVidaJogador.value = vidaJogador;
        MudarVermelho();
        Invoke("MudarBranco", 0.3f);
        
        if (this.vidaJogador <= 0)
        {
            playerAnim.SetBool("Death", true);
            this.vidaJogador = 0;
            Time.timeScale = 0.0f;
            
        }
    }

     public void MudarVermelho()
     {
         sprite.color = new Color(1,0.62f,0.62f, 1);
     }

     public void MudarBranco()
     {
         sprite.color = Color.white;
     }

     public bool Derrotado
     {
         get
         {
             return (this.vidaJogador <= 0);
         }
         
     }
}
