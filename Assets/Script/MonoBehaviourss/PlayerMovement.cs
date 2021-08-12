using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //player object
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb2D;


    //player stat
    [SerializeField] const float playerSpeed = 3.0f;

    //player stat_2
    int playerDir;
    public Vector2 movement = new Vector2();
    

    //player param name
    string Anim_isWalking="isWalking";



    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        animate();
        
    }

    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        movement.x = playerDir * playerSpeed;
        movement.y = rb2D.velocity.y;

        rb2D.velocity = movement;

        if (Input.GetAxisRaw("Jump") == 1)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 3);
            Debug.Log("Jump!!");
        }
        
    }

    void animate()
    {
        playerDir = (int)Input.GetAxisRaw("Horizontal");

        if (playerDir == 1)
        {
            sr.flipX = false;
            anim.SetBool(Anim_isWalking, true);
        }
        else if (playerDir == -1)
        {
            sr.flipX = true;
            anim.SetBool(Anim_isWalking, true);
        }
        else
        {
            anim.SetBool(Anim_isWalking, false);
        }
    }


}
