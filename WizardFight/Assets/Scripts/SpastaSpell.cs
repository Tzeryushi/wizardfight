using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Spasta Bolt
 * Spasta is one of the most rudimentary spells a wizard learns.
 * The spell is well rounded; it is quick, offers reasonable damage, and knocks back your opponent slightly.
 * Those who master the spasta find greater victories in the arena.*/

public class SpastaSpell : Spell
{
    [SerializeField] GameObject spastaBolt;

    public SpastaSpell() : base()
    {
        speed = 10f;
        damage = 10f;
    }
    public SpastaSpell(Entity caster) : base(caster)
    {
    }

    public SpastaSpell(Entity caster, float speed, float damage) : base(caster, speed, damage)
    {
        this.speed = speed;
        this.damage = damage;
    }

    public void Setup(Vector2 direction, float speed, float damage)
    {
        this.speed = speed;
        this.damage = damage;
    }

    public override void Fire()
    {
        GameObject bolt = Instantiate(spastaBolt, transform.position, transform.rotation);
        bolt.GetComponent<SpastaBolt>().Setup(new Vector2(1, 0), 50f, 50f);
    }
    public override void Fire(Vector2 direction)
    {
        direction = direction.normalized;
        GameObject bolt = Instantiate(spastaBolt, transform.position, transform.rotation);
        bolt.GetComponent<SpastaBolt>().Setup(direction, 50f, 50f);
    }

    public override void Fire(GameObject caster, Vector2 direction)
    {
        base.Fire(caster, direction);
    }

    private void Update()
    {
    }
}
