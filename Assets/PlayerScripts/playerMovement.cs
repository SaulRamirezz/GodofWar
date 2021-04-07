using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //private float moveSpeed = 5;
    public float speed;
    public float jumpForce;
    private float moveInput;
    public int sideOrientation;
    public bool AxeIsGrabed = true;
    //private Collision collision;

    private bool isGrounded;
    private bool isClimb;
    private bool isClimbR;
    private bool isClimbL;
    public Vector2 RightOffset;
    public Vector2 GroundOffset;
    public Vector2 LeftOffset;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //collision = GetComponent<Collision>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGrounded);
        isClimb = Physics2D.OverlapCircle((Vector2)transform.position + RightOffset, checkRadius, whatIsGrounded) ||
            Physics2D.OverlapCircle((Vector2)transform.position + LeftOffset, checkRadius, whatIsGrounded);

        isClimbR = Physics2D.OverlapCircle((Vector2)transform.position + RightOffset, checkRadius, whatIsGrounded);
        isClimbL = Physics2D.OverlapCircle((Vector2)transform.position + LeftOffset, checkRadius, whatIsGrounded);
        sideOrientation = isClimbR ? 1 : -1;
        //if (isGrounded = true && Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb2d.velocity = Vector2.up * jumpForce;
        //}
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isClimb = true;
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        //rb2d.AddForce(new Vector2(moveInput * moveSpeed, 0), ForceMode2D.Impulse);
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + GroundOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + RightOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + LeftOffset, checkRadius);
    }
}
