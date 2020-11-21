using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

    [SerializeField]
    private float movSpeed = 5f;
    [SerializeField]
    private float sprintSpeed = 10f;
    private float currentMovSpeed;

    [SerializeField]
    private float jumpForce = 3;

    [SerializeField]
    private float rotSpeed = 5f;

    private Vector3 movement;

    private Rigidbody rigidBody;

    bool isGrounding = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentMovSpeed = movSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f);
        

        ChooseMovSpeed();
        
        Jump();

        UpdateMovementDirection();
    }

    private void FixedUpdate()
    {
        /*Vector3 finalMovement = movement * currentMovSpeed * Time.deltaTime;
        finalMovement.y = rigidBody.velocity.y;
        rigidBody.velocity = finalMovement;*/
        rigidBody.MovePosition(transform.position + movement * currentMovSpeed * Time.deltaTime);
    }

    void UpdateMovementDirection()
    {
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");
        movement = xMov * transform.right + transform.forward * zMov;
        movement.Normalize();
    }

    void ChooseMovSpeed()
    {
        if (Input.GetButton("Sprint"))
            currentMovSpeed = sprintSpeed;
        else
            currentMovSpeed = movSpeed;
    }

    void Jump()
    {
        if (isGrounding)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rigidBody.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y), ForceMode.VelocityChange);
                isGrounding = false;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).point.y < transform.position.y - 0.6)
            isGrounding = true;
    }

}
