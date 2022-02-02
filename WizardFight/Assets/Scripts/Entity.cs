using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected float lifespan;
    protected Vector2 direction;
    protected float speed;
    protected float health;
    protected float size;
    
    public virtual void Move(Vector2 direction) {}
    public virtual void Action1() {}
    public virtual void Action2() {}
    public virtual void Ability1() {}
    public virtual void Ability2() {}
}
