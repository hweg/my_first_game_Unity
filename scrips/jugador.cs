using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public float runSpeed=2;

    public float jumpSpeed=3;

    public float doublejumpspeed = 2.5f;
    private bool candoublejump;

    Rigidbody2D rb2D;

    public bool betterjump = false;
    
    public float fallmultiplier = 0.5f;

    public float lowjumpmultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       rb2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if(checkGround.isGrounded)
            {
                candoublejump = true;
                 rb2D.velocity = new Vector2(rb2D.velocity.x,jumpSpeed);
            }
            else
            {   
                if(Input.GetKeyDown("space"))
                {
                    if(candoublejump)
                    {
                        animator.SetBool("doublejump",true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x,doublejumpspeed);
                        candoublejump = false;

                    }

                }
            }
           
        }

        if(checkGround.isGrounded==false)
        {
            animator.SetBool("jump",true);
            animator.SetBool("run",false);
            
        }
        if(checkGround.isGrounded==true)
        {
            animator.SetBool("jump",false);
            animator.SetBool("doublejump",false);
              
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d")|| Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("run",true);
        }
    
        else if (Input.GetKey("a")|| Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("run",true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("run",false);
        }
        

        if (betterjump)
        {   
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity +=Vector2.up*Physics2D.gravity.y * (fallmultiplier) * Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity +=Vector2.up*Physics2D.gravity.y * (lowjumpmultiplier) * Time.deltaTime;
            }

        }



    }
}
