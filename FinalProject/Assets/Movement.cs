using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 movement;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical);

        animator.SetBool(name:"isMoving", moveHorizontal != 0);

        //set direction of sprite when walking
        if(movement.x < 0) {
        spriteRenderer.flipX = true;
        } else if (movement.x > 0) {
            spriteRenderer.flipX = false;
        }

    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //rb.MovePosition(transform.position + (new Vector3(moveHorizontal,moveVertical)) * Time.fixedDeltaTime * moveSpeed);

    }

}
