using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool jumpTouch;
    public float jumpForce;
    public float Speed;
    private Rigidbody2D rigBod;
    public Vector2 force;


    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

       
        if (jumpTouch)
        {
            rigBod.AddForce(Vector2.up * jumpForce * Speed);
            jumpTouch = false;
            //Debug.Log("JE SAUUUTE ");
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

        // if (Input.GetKey(KeyCode.RightArrow))
        //{
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //   transform.Translate(Vector2.up + Vector2.right * Time.deltaTime * Speed);
        //}
        //}

    }
}
