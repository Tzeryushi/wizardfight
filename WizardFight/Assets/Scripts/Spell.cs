using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*SPELL ABSTRACT
 * Spells handle instantiation and effects that do not require new game objects.
 * Bolts, summons, and creatures SHOULD BE REPRESENTED AS DIFFERENT OBJECTS
 * The spell will create the effect(s) and set parameters. This is the way.
 * 
 * Why?
 * Imagine you want to make a spell that produces multiple effects.
 * If the spell was the object instantiated, this would require that subsequent events bounce off the first recursively.
 * What about spells that create multiple physics objects simultaneously?
 * Should we have to call the same spell multple times to acheive this?
 * No. The spell is a container for the effects, which streamlines usage.
 * This also makes spell swapping easier!
 */

public abstract class Spell : MonoBehaviour
{
    [SerializeField] protected float castSpeed = 1;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float speedMultiplier = 1;
    [SerializeField] protected float damage = 1;
    [SerializeField] protected float lifespan = 1;
    protected Vector2 initialDirection;
    protected Vector2 direction;
    protected Vector2 location;

    public Spell()
    {

    }
    public Spell(Vector2 direction)
    {
        initialDirection = direction;
    }
    public Spell(Vector2 direction, float speed, float damage)
    {
    }

    //Getters and Setters
    public void SetSpeed(float speed) { this.speed = speed; }
    public float GetSpeed() { return speed; }
    public void SetCastSpeed(float castSpeed) { this.castSpeed = castSpeed; }
    public float GetCastSpeed() { return castSpeed; }
    public void SetSpeedMultiplier(float speedMultiplier) { this.speedMultiplier = speedMultiplier; }
    public float GetSpeedMultiplier() { return speedMultiplier; }
    public void SetDamage(float damage) { this.damage = damage; }
    public float GetDamage() { return damage; }
    public void SetLifespan(float lifespan) { this.lifespan = lifespan; }
    public float GetLifespan() { return lifespan; }
    public Vector2 GetInitialDirection() { return initialDirection; }
    public void SetDirection(Vector2 direction) { this.direction = direction; }
    public Vector2 GetDirection() { return direction; }
    public Vector2 GetLocation() { return location; }
}
