using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class hareket : MonoBehaviour
{
    Rigidbody2D rb;
    public float horizontal;
    public float speed = 500;
    public float jumpforce = 5;
    public LayerMask IsGround;
    public LayerMask Walllayer;
    public float checkRadius = 0.27f;
    public float extrajump;
    public float extrajumpValue = 1;
    Animator ar;
    BoxCollider2D bc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        
        
        
    }


    void Update()
    {

        if (IsGrounded())
        {
            extrajump = extrajumpValue;
        }
        if(Input.GetKeyDown(KeyCode.Space) && extrajump > 0)
        {
            Jump();

        }
        if (horizontal > 0.01f)
        {
            transform.localScale = new Vector3(6, 6, 6);
        }
        else if (horizontal < 0) {
            transform.localScale = new Vector3(-6,6,6);
        }
        ar.SetBool("Grounded", IsGrounded());
        


        if(OnWall() && !IsGrounded())
        {
            rb.gravityScale = 0;
            rb.velocity = Vector3.zero; 
        }
        else
        {
            rb.gravityScale = 1;
        }


       
    }
    private void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(horizontal * Time.deltaTime * speed, rb.velocity.y, 0);
        ar.SetBool("run",horizontal != 0);
        
    }
    private void Jump()
    {
        ar.SetTrigger("jump");
        //rb.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x,jumpforce);
        extrajump--;
    }
    
    private bool IsGrounded()
    {
        RaycastHit2D raycashit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.down, 0.1f,IsGround);
        return raycashit.collider != null;
    }
    private bool OnWall()
    {
        RaycastHit2D raycashit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0,new Vector2(transform.localScale.x,0), 0.1f, Walllayer);
        return raycashit.collider != null;
    }

    
}
