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

//TODO: Clean up structure. Direction and InitialDirection are functionally indistinguiashable from each other.
//Locations of projectiles and spell effects will be charted by those effects. Spells are essentially the weapons,
//the effects themselves are the bullets.
public abstract class Spell : MonoBehaviour
{
    [SerializeField] protected float castSpeed = 1;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float speedMultiplier = 1;
    [SerializeField] protected float damage = 1;
    [SerializeField] protected float lifespan = 1;
    protected Entity caster;

    public Spell() {}
    public Spell(Entity caster) {} //in order to define a caster apart from the original user
    public Spell(Entity caster, float speed, float damage) {} //quickly initialize with some parameters. Likely redundant.

    public virtual void Fire() {} //should be very rarely used, but would be a global spell. Failsafe, preset direction.
    public virtual void Fire(Vector2 direction) {} //would use the location of the current monobehavior to fire. Uses ownership of spell.
    public virtual void Fire(Vector2 direction, Vector2 location) {} //uses ownership of spell.
    public virtual void Fire(GameObject caster, Vector2 direction) {} //basic, spell has ownership and direction. Instantiates on monobehaviour location.
    public virtual void Fire(GameObject caster, Vector2 direction, Vector2 location) {} //location is given.

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
}
