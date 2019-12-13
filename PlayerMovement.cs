using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float moveSpeed = 7f;
    public float jumpForce = 7f;
    private bool isCollidingWithWall;
    private bool isCollidingWithFloor;
    private bool isJumping;
    public bool levelComplete;
    public int jumpCount;
    static Animator anim;
    void Start()
    {
        //anim = GetComponent<Animator>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if(isCollidingWithFloor || isCollidingWithWall)
        {
            jumpCount = 0;
        }

        if (isCollidingWithFloor || isJumping)
        {
            rb.AddRelativeForce(Vector3.right * moveSpeed);            
        }

        if (isCollidingWithWall && isJumping)
        {
            isJumping = false;
            rotate();            
        }

        if (jumpCount <= 2 && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space)))
        {
            jumpCount++;
            jump();
            //Debug.Log("Is jumping!");
        }

        if (!isJumping && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space)))
        {
            jump();
            //Debug.Log("Is jumping!");
        }

        if (isCollidingWithWall)
        {
            Debug.Log("Player is wall sliding");
            anim.SetBool("isWallSliding", true);
        }

        if (isCollidingWithFloor)
        {
            anim.SetBool("isWallSliding", false);
        }

        //else if(isCollidingWithFloor == true)
        //{
        //    anim.SetBool("isWallSliding", false);
        //    Debug.Log("Player has stopped wall sliding");
        //}

        //Debug.Log(gameObject.transform.eulerAngles.y);
    }

    private void Update()
    {
        //if (isCollidingWithWall)
        //{
        //    Debug.Log("Player is wall sliding");
        //    anim.SetTrigger("isWallSliding");
        //}
    }

    public void rotate()
    {
        transform.Rotate(new Vector3(0, 180f, 0));
    }

    //void rotate90()
    //{
    //    transform.Rotate(new Vector3(0, 90f, 0));
    //}

    public void jump()
    {
        //rb.AddForce(new Vector3(0f, jumpForce, 0f));
        anim.SetTrigger("isJumping");
        anim.SetBool("isWallSliding", false);
        rb.velocity = (new Vector3(0f, jumpForce, 0f));
        isJumping = true;
    }

    public void dive()
    {
        anim.SetTrigger("dive");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("Hit a wall!");
            isCollidingWithWall = true;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            //Debug.Log("On the floor!");
            isCollidingWithFloor = true;
            isJumping = false;
            //Debug.Log("Is not jumping!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("Not hitting a wall!");
            isCollidingWithWall = false;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            //Debug.Log("Not on the floor!");
            isCollidingWithFloor = false;
        }
    }
}
