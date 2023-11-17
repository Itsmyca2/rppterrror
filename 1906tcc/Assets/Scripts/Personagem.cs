using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using TMPro;

public class Personagem : MonoBehaviour
{
    public float velocidadeMax;
    public float velocidade;
    public float forcaPulo;
    private Rigidbody2D rig;
    private SpriteRenderer sprite;
    private Animator playerAnim;
    [Header("Lugar do Ataque")] 
    public Transform attackCheck;
    private float attackCheckX;
    
    
    public int vidaJogador;
    public Slider barraVidaJogador;
    public Slider barraManaJogador;
    public float quantidadeAtualMagia;
    public float quantidadeMaxMagia;
    public GameObject magia;
    public Transform pontoMagia;
    

    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEChao;
   
    
    public float raioAtaque;
    public LayerMask layerEnemy;
    float tempoProximoAtaque;
    private float tempoAtaque;
    public GameObject ponteI;
    public GameObject ponteII;

    public Vector2 boxSize;
    public float castDistance;

    public bool recebendoDanoChefao;

    public float groundGravity = 5f;
    public float jumpTime = 0.1f;
    private float lastJumpTime;
    public bool colidindoPersonagem;

    private TextMeshProUGUI textoMoeda;
    
    private AudioSource caminhadaSom;
    public AudioSource poderSom;
    public AudioSource puloSom;
    public AudioSource ataqueEspadaSom;



    // Start is called before the first frame update
    void Start()
    {

        

        colidindoPersonagem = false;
        playerAnim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
        attackCheckX = attackCheck.localPosition.x;
        quantidadeAtualMagia = quantidadeMaxMagia;
        barraManaJogador.maxValue = quantidadeAtualMagia;
        barraManaJogador.value = quantidadeAtualMagia;

        barraVidaJogador.maxValue = vidaJogador;
        barraVidaJogador.value = vidaJogador;
       // textoMoeda = GameObject.FindWithTag("textoMoeda").GetComponent<TextMeshProUGUI>();
        
        
        

    }

    private void Awake()
    {
        caminhadaSom = GetComponent<AudioSource>();
        //poderSom = GetComponent<AudioSource>();
        //puloSom = GetComponent<AudioSource>();
        //ataqueEspadaSom = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        DetectarChao();
        Jump();
        Attack();
        AtirandoMagia();

        if (Input.GetButtonDown("Horizontal") && taNoChao)
        {
            //caminhadaSom.Play();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SomPulo()
    {
        Debug.Log("Som de pulo");
        puloSom.Play();
    }
    
    public void SomAttack()
    {
        Debug.Log("Som de ataque");
        ataqueEspadaSom.Play();
    }
    void Move()
    {
        
        float horizontalMovimento = Input.GetAxisRaw("Horizontal");
        
        rig.velocity = new Vector2(horizontalMovimento * velocidade, rig.velocity.y);

        if (rig.velocity.magnitude > velocidadeMax)
        {
            rig.velocity = rig.velocity.normalized * velocidadeMax;
        }
        
        
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
            caminhadaSom.Stop();
            playerAnim.SetBool("Walk", false);
            
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && taNoChao)
        {
            
            playerAnim.SetBool("Attack", false);
            rig.gravityScale = 1f;
            lastJumpTime = Time.time;
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
        }
        
    }

    void AtirandoMagia()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            
            playerAnim.SetBool("AttackMagia", true);
            if (quantidadeAtualMagia > 1)
            {
                poderSom.Play();
                MagiaJogador magiaJogador = Instantiate(magia, pontoMagia.position, pontoMagia.rotation = Quaternion.Euler(0, 0, 0)).GetComponent<MagiaJogador>();
                magiaJogador.left = sprite.flipX;
                if (magiaJogador.left)
                {
                    magiaJogador.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    magiaJogador.GetComponent<SpriteRenderer>().flipX = false;
                }

                quantidadeAtualMagia -= 1;
                barraManaJogador.value = quantidadeAtualMagia;
                
            }
            
        }

        else
        {
            playerAnim.SetBool("AttackMagia", false);
        }
    }

    void DetectarChao()
    {
        playerAnim.SetFloat("VelocityY", rig.velocity.y);
        
        bool taOnde = Physics2D.BoxCast(detectaChao.position, boxSize,0, Vector2.down,castDistance,oQueEChao);

        if (taOnde)
        {
            taNoChao = true;
            if(Time.time > lastJumpTime + jumpTime) rig.gravityScale = groundGravity;
        }
        else
        {
            taNoChao = false;
            rig.gravityScale = 1f;
        }
        
        playerAnim.SetBool("TaNoChao", taNoChao);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(detectaChao.position, boxSize);
        
        Gizmos.DrawLine(detectaChao.position, detectaChao.position + castDistance*Vector3.down );
        
        Gizmos.DrawWireCube(detectaChao.position+castDistance*Vector3.down, boxSize);
        
        //Gizmos.DrawSphere(detectaChao.position,0.2f);
        Gizmos.DrawSphere(attackCheck.position, raioAtaque);
    }

    

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("plataformamovimento"))
        {
            transform.parent = null;
        }
    }

    private void Attack()
    {
        tempoAtaque -= Time.deltaTime;
        
       if (tempoAtaque <= 0)
        {
            if (Input.GetButtonDown("Fire1") && colidindoPersonagem == false)
            {
                playerAnim.SetTrigger("Attack");
                tempoAtaque = 0.2f;
                PlayerAttack();
                ataqueEspadaSom.Play();
            }
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
            
        if (recebendoDanoChefao)
        {
            vidaJogador -= 5;
        }

        barraVidaJogador.value = vidaJogador;
        MudarVermelho();
        Invoke("MudarBranco", 0.3f);
        
        if (this.vidaJogador <= 0)
        {
            playerAnim.SetBool("Death", true);
            this.vidaJogador = 0;
            //Time.timeScale = 0.0f;
            SceneManager.LoadScene("Game Over");

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

    
     public void ColetarMoedas()
     {
         quantidadeAtualMagia++;
         barraManaJogador.value = quantidadeAtualMagia;
         
     }
     
     private void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("deadzone"))
         {
             SceneManager.LoadScene("SampleScene");
         }
         

         if (other.gameObject.CompareTag("pocao vida"))
         {
             barraVidaJogador.maxValue = vidaJogador;
         }
         
         if (other.gameObject.CompareTag("plataforma"))
         {
             forcaPulo = 10;
         }

         if (other.gameObject.CompareTag("espinhos"))
         {
             vidaJogador -= 1;
             barraVidaJogador.value = vidaJogador;
             MudarVermelho();
            
             Invoke("MudarBranco", 0.3f);
         }

         if (other.gameObject.CompareTag("alavanca"))
         {
             ponteI.SetActive(true);
             ponteII.SetActive(true);
         }

         if (other.gameObject.CompareTag("plataformamovimento"))
         {
             transform.parent = other.transform;
         }
        
     }

     public void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.CompareTag("mago"))
         {
             colidindoPersonagem = true;
             
         }
     }

     public void OnTriggerExit2D(Collider2D other)
     {
         
         if (other.gameObject.CompareTag("mago"))
         {
             colidindoPersonagem = false;
             
         }
     }
     
}
