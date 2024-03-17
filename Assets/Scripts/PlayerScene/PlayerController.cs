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
    //public Animator animator;

    void Start()
    {
        ck = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovementUpdate();
        JumpUpdate();
    }

    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        var run_int = 0;


        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            run_int = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            run_int = 4;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            run_int = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            run_int = 3;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speed + sprint;
        }
        else { currentSpeed = speed; }

        //animator.SetInteger("run_int", run_int);
    }

    private void JumpUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && ck.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
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
