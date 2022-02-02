using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Entity
{
    private Rigidbody2D rb;
    [SerializeField] new float speed;

    public override void Move(Vector2 direction)
    {
        this.direction = direction;
        rb.AddForce(direction * Time.deltaTime * speed, ForceMode2D.Force);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Debug.Log(direction);
    }
}
