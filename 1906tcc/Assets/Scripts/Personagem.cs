using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    //private GameObject lugarataque = GameObject.FindWithTag("lugarataque");
    
    public int velocidade;
    public float forcaPulo;
    private Rigidbody2D rig;
    public int vidaJogador;
    
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


    
    private InimigoUm inimigo;


    // Start is called before the first frame update
    void Start()
    {
        inimigo = GameObject.Find("Cavaleiro").GetComponent<InimigoUm>();
        playerAnim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        attackCheckX = attackCheck.localPosition.x;
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
            enemiesAttack [i].SendMessage ("Inimigo");
            Debug.Log (enemiesAttack [i].name);
        }

        if (enemiesAttack != null)
        {
            inimigo.ReceberDano();
        }
    }

     public void ReceberDano()
    {
        vidaJogador--;
    }
}
