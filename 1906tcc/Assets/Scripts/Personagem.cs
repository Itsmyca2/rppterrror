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

    
    
    // Start is called before the first frame update
    void Start()
    {
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
            sprite.flipX = false;
        }

        else if (horizontalMovimento < 0)
        {
            sprite.flipX = true;
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && taNoChao)
        {
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
        }
    }

    void DetectarChao()
    {
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
}
