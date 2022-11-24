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

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(
            horizontalInput * walkForce,
            rb.velocity.y,
            verticalInput * walkForce
        );

        if (Input.GetButtonDown("Jump"))
        {
            if (this.canJump)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                this.canJump = false;
            }
        }
    }
}
