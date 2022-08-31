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
    public byte CurrentJumpCount = 1;
    public Animator animManager;
    public Vector2 playerAxis;



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
            animManager.SetBool("jumping", true);
            animManager.SetBool("trigJump", true);
            jumpTouch = false;
            Debug.Log("JE SAUTE ");

            whileOnJump = true;
        }
        if (DoubleJump == true)
        {
            CurrentJumpCount++;
            rigBod.AddForce(Vector2.up * jumpForce * 5);
            DoubleJump = false;
            Debug.Log("JE RE-SAUUUTE ");
         
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

    // Update is called once per frame
    void Update()
    {
        bool runOnF = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            runOnF = true;
            this.transform.localScale = new Vector3(1, 1, 1);
        }
   

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
            runOnF = true;
            this.transform.localScale = new Vector3(-1, 1, 1);
  

        }

        if (runOnF == true)
        {
            animManager.SetBool("running", true);
        }else
        {
            animManager.SetBool("running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (whileOnJump == true)
            {
                //!on est en plein saut, on sait pas combien de sauts ont été
                if (CurrentJumpCount == 1)
                {
                    DoubleJump = true;
                }
            }
            else
            {
                jumpTouch = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
                if (collision.gameObject.tag == "ground")
                {
                    CurrentJumpCount = 0;
                    whileOnJump = false;
                    animManager.SetBool("jumping", false);
                    animManager.SetBool("falling", false);

                }
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
