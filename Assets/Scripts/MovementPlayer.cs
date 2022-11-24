using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

    Rigidbody rb;
    public float jumpForce;
    public float walkForce;
    bool canJump;
    //called before first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.canJump = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(Vector3.forward * 1 * walkForce, ForceMode.Acceleration);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector3.left * 1 * walkForce, ForceMode.Acceleration);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(Vector3.forward * -1 * walkForce, ForceMode.Acceleration);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector3.left * -1 * walkForce, ForceMode.Acceleration);
        }

        if (Input.GetKeyDown("space"))
        {
            if (this.canJump)
            {
                //jump
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                this.canJump = false;
            }
        }
    }
}
