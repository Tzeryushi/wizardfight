using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWizardInput : MonoBehaviour
{

    private PlayerInput playerInput;
    private Rigidbody2D rb;

    //controls
    private InputAction move;

    //variables
    Vector2 moveDirection = Vector2.zero;

    //parameters
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float impulseSpeed = 10.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        move.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Start()
    {
        //testing input subscriptions
        //move.started += Blast;
    }

    //private void Blast(InputAction.CallbackContext context)
    //{
    //    if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) < 2)
    //    {
    //        moveDirection = move.ReadValue<Vector2>();
    //        Debug.Log(moveDirection);
    //        rb.velocity = (moveDirection*impulseSpeed);
    //        //rb.AddForce(moveDirection * impulseSpeed, ForceMode2D.Impulse);
    //        Debug.Log("Blasted!");
    //    }
    //}

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) < 0.01f)
        {
            rb.velocity = (moveDirection * impulseSpeed);
        }
        else
        {
            rb.AddForce(moveDirection * Time.deltaTime * moveSpeed, ForceMode2D.Force);
        }
            
        //rb.velocity = (moveDirection * Time.deltaTime * moveSpeed);
    }

    //private Rigidbody2D playerRigidBody;
    //public PlayerInputActions playerControls;

    //Vector2 moveDirection = Vector2.zero;   //will be assigned to the move input vector
    //private InputAction move;
    //private InputAction fire;

    //[SerializeField] float moveSpeed = 0.01f;
    //[SerializeField] float turnSpeed = 0.01f;

    //private void Awake()
    //{
    //    playerRigidBody = GetComponent<Rigidbody2D>();
    //    playerControls = new PlayerInputActions();

    //}

    //private void OnEnable()
    //{
    //    move = playerControls.Player.Move;
    //    move.Enable();
    //}

    //private void OnDisable()
    //{
    //    move.Disable();

    //    //disabling subscriptions
    //    playerControls.Player.Spell.started -= Spell;
    //    playerControls.Player.Spell.performed -= Spell;
    //    playerControls.Player.Spell.canceled -= Spell;
    //}

    //private void Start()
    //{
    //    //callbacks to determine states
    //    playerControls.Player.Spell.started += Spell;
    //    playerControls.Player.Spell.performed += Spell;
    //    playerControls.Player.Spell.canceled += Spell;
    //}

    //private void Spell(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Spell");
    //    //context.ReadValue<float>();
    //    //context.ReadValueAsButton();
    //}

    //private void Update()
    //{
    //    moveDirection = move.ReadValue<Vector2>();  //assigned to input
    //}

    //private void FixedUpdate()
    //{
    //    playerRigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    //}
    //public void Move()
    //{
    //    transform.Translate(0, moveSpeed, 0);
    //}
}
