using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move_Proto : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;

    private float playerSpeed = 365f;
    private float maxSpeed = 1000f;
    public float xSpeed;
    public float jumpPower = 25f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;


    private Rigidbody2D rb2d;
    private Animator anim;
    public bool grounded;

    // Use this for initialization
    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        PlayerMove();
    }
 
     void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));   

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * playerSpeed);
        }
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        } if (h > 0 && !facingRight)
        {
            FlipPlayer();
        } else if (h < 0 && facingRight)
        {
            FlipPlayer();
        }
        if (Input.GetButtonDown("Jump") && grounded) 
        {
            jump();
        }
        anim.SetBool("Grounded", grounded);
    }

    void jump()
    {
        anim.SetBool("Grounded", grounded);
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        grounded = false;

    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 currScale = rb2d.transform.localScale;                                                          // get the current scale of the rigid body
        currScale.x *= -1;                                                                                      // reverse
        rb2d.transform.localScale = currScale;                                                                  // set again
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Block" || collision.gameObject.tag == "Platform") {
            grounded = true;
        }

		if (collision.gameObject.tag == "SpaceShip") {
			SceneManager.LoadScene ("congratulations");
		}

        if (collision.gameObject.tag == "Enemy")
        {

            float x = Input.GetAxis("Horizontal");
            

           
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10* x * jumpPower,  jumpPower) );
            //rb2d.AddForce(Vector2.up * 10f);
            gameObject.GetComponent<Player_Healthbar>().health--;
            

        }
    }
}
