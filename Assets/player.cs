using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Speed = 20f;
    private bool jumpPressed;
    private Rigidbody rigBod;

    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }
    private void FixedUpdate()
    {
        if (jumpPressed)
        {
            // on demande à la touche space de multiplier par 5 la force du saut par la vélocité
            rigBod.AddForce(Vector2.up * 5, ForceMode.VelocityChange);
            jumpPressed = false;
        }
    }
}
