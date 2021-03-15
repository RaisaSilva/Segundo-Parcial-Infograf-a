using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoM : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Vector2 movement;
    public float speed;
    public float jumpForce;


//chocar con el piso
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
//¿? esta en el piso
    private bool isGrounded;



    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontalInput, 0f);
        if (horizontalInput < 0f)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if (horizontalInput > 0f)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }

    void FixedUpdate()
    {
        
        float horizontalVelocity = movement.normalized.x * speed;
        rigidbody.velocity = new Vector2(horizontalVelocity, rigidbody.velocity.y);

    }
    
    void LateUpdate()
    {
           
        animator.SetBool("Idle", movement == Vector2.zero);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("VerticalVelocity", rigidbody.velocity.y);
    }
}

