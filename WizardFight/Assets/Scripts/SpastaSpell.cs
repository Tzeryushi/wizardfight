using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Spasta Bolt
 * Spasta is one of the most rudimentary spells a wizard learns.
 * The spell is well rounded; it is quick, offers reasonable damage, and knocks back your opponent slightly.
 * Those who master the spasta find greater victories in the arena.*/

public class SpastaSpell : Spell
{
    [SerializeField] SpastaBolt bolt;

    public SpastaSpell(Vector2 direction) : base(direction)
    {
        speed = 10f;
        damage = 10f;
        this.direction = direction;
        initialDirection = direction;
    }
    public SpastaSpell(Vector2 direction, float speed, float damage) : base(direction, speed, damage)
    {
        this.speed = speed;
        this.damage = damage;
        this.direction = direction;
        Destroy(gameObject, 5f);
    }

    public void Setup(Vector2 direction, float speed, float damage)
    {
        this.speed = speed;
        this.damage = damage;
        this.direction = direction;
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
}
