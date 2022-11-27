using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField] bool areWePlayer2 = false;

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

        float horizontalInputPlayer1 = Input.GetAxis("HorizontalP1");
        float verticalInputPlayer1 = Input.GetAxis("VerticalP1");

        float horizontalInputPlayer2 = Input.GetAxis("HorizontalP2");
        float verticalInputPlayer2 = Input.GetAxis("VerticalP2");


        float hi;
        float vi;

        if (this.areWePlayer2)
        {
            hi = horizontalInputPlayer2;
            vi = verticalInputPlayer2;
        }
        else
        {
            hi = horizontalInputPlayer1;
            vi = verticalInputPlayer1;
        }

        rb.velocity = new Vector3(
            hi * walkForce,
            rb.velocity.y,
            vi * walkForce
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
