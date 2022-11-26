using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float walkForce = 5f;

    [SerializeField] Transform feet;
    [SerializeField] LayerMask layerGround;



    //called before first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            this.Jump();
        }
    }


    bool isFeetTouchingGround()
    {
        return Physics.CheckSphere(feet.position, 0.1f, layerGround);
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
            if (this.isFeetTouchingGround())
            {
                this.Jump();
            }
        }
    }
}
