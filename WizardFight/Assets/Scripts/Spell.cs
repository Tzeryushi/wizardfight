using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    int castTime;
    private Vector3 initialDirection;

    public Spell()
    {

    }
    public Spell(Vector3 direction)
    {
        initialDirection = direction;
    }
    public Spell(Vector3 direction, float speed, float damage)
    {
    }
}
