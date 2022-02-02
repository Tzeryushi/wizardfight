using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//TODO: Instantiate Commands as singletons - method?
//TODO: Commands into lists that can be replayed over time

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;

    //controllers
    private InputAction move;
    private InputAction spell;

    //variables
    private bool isMoving;

    //parameters
    [SerializeField] Entity actor;

    private void Awake()
    {
        isMoving = false;
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
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
        move.started -= MoveStart;
        move.canceled -= MoveEnd;
        spell.Disable();
        spell.started -= Spell;
    }

    // Start is called before the first frame update
    void Start()
    {
        move.started += MoveStart;
        move.canceled += MoveEnd;
        spell.started += Spell;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isMoving);
        if(isMoving)
        {
            MoveCommand moveActor = new MoveCommand(actor, move.ReadValue<Vector2>());
            moveActor.Execute();
        }
    }

    private void MoveStart(InputAction.CallbackContext context)
    {
        isMoving = true;
        //Debug.Log("Start Move");
    }

    private void MoveEnd(InputAction.CallbackContext context)
    {
        isMoving = false;
        //Debug.Log("End Move");
    }

    private void Spell(InputAction.CallbackContext context)
    {
        //these calls will later need to 
        ActionCommand1 castSpell = new ActionCommand1(actor);
        castSpell.Execute();
    }
}
