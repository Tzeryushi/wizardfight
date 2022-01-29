using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpastaSpell : Spell
{
    private float speed;
    private float damage;
    private Vector3 direction;

    public SpastaSpell(Vector3 direction) : base(direction)
    {
        speed = 10f;
        damage = 10f;
        this.direction = direction;
        Destroy(gameObject, 5f);
    }
    public SpastaSpell(Vector3 direction, float speed, float damage) : base(direction, speed, damage)
    {
        this.speed = speed;
        this.damage = damage;
        this.direction = direction;
        Destroy(gameObject, 5f);
    }

    public void Setup(Vector3 direction, float speed, float damage)
    {
        this.speed = speed;
        this.damage = damage;
        this.direction = direction;
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
