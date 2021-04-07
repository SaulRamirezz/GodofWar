using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveSpeed = 2;
    public const string RIGHT = "right";
    public const string LEFT = "left";

    string buttonPressed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            buttonPressed = RIGHT;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            buttonPressed = LEFT;
        }
        else
        {
            buttonPressed = null;
        }
    }

    private void FixedUpdate()
    {
        if (buttonPressed == RIGHT)
        {
            rb2d.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
        }
        else if (buttonPressed == LEFT)
        {
            rb2d.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);
        }
        else
        {

        }
    }
}
