using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool jumpTouch;
    public bool DoubleJump;
    public bool whileOnJump;
    public float jumpForce;
    public float Speed;
    private Rigidbody2D rigBod;
    public Vector2 force;
    public byte MaxJumpCount = 2;
    private byte CurrentJumpCount = 1;


    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (jumpTouch)
        {
            CurrentJumpCount++;
            rigBod.AddForce(Vector2.up * jumpForce * Speed);
            jumpTouch = false;
            Debug.Log("JE SAUTE ");

            whileOnJump = true;
        }
        if (DoubleJump == true)
        {
            rigBod.AddForce(Vector2.up * jumpForce * 5);
            DoubleJump = false;
            Debug.Log("JE RE-SAUUUTE ");
         //   if (CurrentJumpCount == MaxJumpCount)
           // {
             //   jumpTouch = false;
            //}
        }

        if (this.rigBod.velocity.y < 0)
        {
            rigBod.gravityScale = 3;
        }
        else
        {
            rigBod.gravityScale = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            CurrentJumpCount = MaxJumpCount;
        }if (CurrentJumpCount == MaxJumpCount) 
        {
            CurrentJumpCount = 0;
            DoubleJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (whileOnJump == true)
            {
                DoubleJump = true;
            }
            else
            {
                jumpTouch = true;
            }
          



            //if (jumpTouch)
            //{
            //Debug.Log("================ update : " + jumpTouch);
            //}
            //   else
            //  {
            //Debug.Log("update:" + jumpTouch);
            //}
        }
    }
}
