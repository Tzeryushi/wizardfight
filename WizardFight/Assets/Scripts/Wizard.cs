using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//TODO: Spells!

public class Wizard : Entity
{
    private Rigidbody2D rb;
    [SerializeField] float holdDistance = 1.0f;
    [SerializeField] float wandLength;
    [SerializeField] GameObject wand;

    public override void Move(Vector2 direction)
    {
        this.direction = direction;
    }

    public override void Action1()
    {
        Spell mySpell1 = wand.GetComponent<Spell>();
        Vector2 launchVector = new Vector2(wand.transform.position.x - transform.position.x, wand.transform.position.y - transform.position.y).normalized;
        //Debug.Log(launchVector);
        mySpell1.Fire(launchVector);
        Debug.Log("Test1");
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 400;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 parentPosition = new Vector2(transform.position.x, transform.position.y);
        wand.transform.position = parentPosition + (mouseNormal() * holdDistance);
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * Time.deltaTime * speed, ForceMode2D.Force);
        direction = Vector2.zero;
    }

    //This wil need to be changed! Is it possible to get input as a vector to the mouse, like a cstick? Mr. Unity?
    //mouseNormal gets the normal vector to the position of the mouse from the location of the current body.
    private Vector2 mouseNormal()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector2 worldPosition2D = new Vector2(worldPosition.x, worldPosition.y);
        Vector2 launchVector = new Vector2(worldPosition.x - transform.position.x, worldPosition.y - transform.position.y).normalized;
        return launchVector;
    }
}
