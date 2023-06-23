using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public int velocidade;
    public float forcaPulo;
    private Rigidbody2D rig;
    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEChao;
    private SpriteRenderer sprite;
    private Animator playerAnim;



    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        DetectarChao();
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
            sprite.flipX = false;
        }

        else if (horizontalMovimento < 0)
        {
            playerAnim.SetBool("Walk", true );
            sprite.flipX = true;
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
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);

        }
        taNoChao = true;
    }

    void DetectarChao()
    {
        //playerAnim.SetBool("Jump", false);
        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEChao);
        
        
        /*
        //  Collider2D chaoCollider = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEChao);

        RaycastHit2D chaoHit = Physics2D.CircleCast(detectaChao.position, 0.2f, Vector2.zero, 0, oQueEChao);
        taNoChao = Mathf.Abs(chaoHit.point.x - transform.position.x) <= 0.1f;*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(detectaChao.position,0.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            playerAnim.SetBool("Jump", false);
        }
    }
}
