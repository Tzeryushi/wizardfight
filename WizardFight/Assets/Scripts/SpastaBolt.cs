using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpastaBolt : MonoBehaviour
{
    private float speed;
    private float damage;
    private Vector2 direction;

    public SpastaBolt(Vector2 direction)
    {
        speed = 10f;
        damage = 10f;
        this.direction = direction;
        Destroy(gameObject, 5f);
    }
    public SpastaBolt(Vector2 direction, float speed, float damage)
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