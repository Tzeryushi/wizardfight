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
    private InputAction spell;

    //variables
    Vector2 moveDirection = Vector2.zero;

    //parameters
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float impulseSpeed = 10.0f;
    [SerializeField] float launchSpeed = 50f;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject launcher;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        move.ReadValue<Vector2>();
        spell = playerInput.actions["Spell"];
    }

    private void OnEnable()
    {
        move.Enable();
        spell.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        spell.Disable();
        spell.started -= Spell;
    }

    private void Start()
    {
        //testing input subscriptions
        //move.started += Blast;
        spell.started += Spell;
    }

    private void Spell(InputAction.CallbackContext context)
    {
        //Vector3 mousePosition = Mouse.current.position.ReadValue();
        //mousePosition.z = Camera.main.nearClipPlane;
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector2 worldPosition2D = new Vector2(worldPosition.x, worldPosition.y);
        //Vector2 launchVector = new Vector2 (worldPosition.x - launcher.transform.position.x, worldPosition.y - launcher.transform.position.y).normalized;

        Vector2 launchVector = new Vector2(launcher.transform.position.x - transform.position.x, launcher.transform.position.y - transform.position.y).normalized;
        Debug.Log(launchVector);
        GameObject bolt = Instantiate(projectile, launcher.transform.position, launcher.transform.rotation);
        bolt.GetComponent<Rigidbody2D>().AddRelativeForce(launchVector*launchSpeed);
        
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
