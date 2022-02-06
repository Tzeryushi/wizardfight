using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Spells!

public class Wizard : Entity
{
    private Rigidbody2D rb;
    [SerializeField] GameObject wand;

    public override void Move(Vector2 direction)
    {
        this.direction = direction;
    }

    public override void Action1()
    {
        Spell mySpell1 = wand.GetComponent<Spell>();
        mySpell1.Fire(new Vector2(0, 1));
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
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * Time.deltaTime * speed, ForceMode2D.Force);
        direction = Vector2.zero;
    }
}
