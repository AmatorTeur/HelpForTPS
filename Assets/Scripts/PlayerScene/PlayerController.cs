using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float sprint = 10f;
    public float gravity = 9.8f;
    private float _fallVelocity;
    public float jumpForce;
    private CharacterController ck;
    private Vector3 _moveVector;
    private float currentSpeed;

    void Start()
    {
        ck = GetComponent<CharacterController>();
    }

    void Update()
    {
        _moveVector = Vector3.zero;



        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }


        if (Input.GetKey(KeyCode.Space) && ck.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speed + sprint;
        }
        else { currentSpeed = speed;  }
    }

    void FixedUpdate()
    {
        ck.Move(_moveVector* currentSpeed * Time.fixedDeltaTime);
        _fallVelocity += gravity * Time.fixedDeltaTime;
        ck.Move(Vector3.down* _fallVelocity * Time.fixedDeltaTime);

        if (ck.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
