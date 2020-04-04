using UnityEngine;

public class Damageable : MonoBehaviour
{
    //[Tooltip("Multiplier to apply to the received damage")]
    public float damageMultiplier = 1f;
    [Range(0, 1)]
    //[Tooltip("Multiplier to apply to self damage")]
    public float sensibilityToSelfdamage = 0.5f;

    public Health health { get; private set; }

    void Awake()
    {
        // find the health component either at the same level, or higher in the hierarchy
        health = GetComponent<Health>();
        if (!health)
        {
            health = GetComponentInParent<Health>();
        }
    }
    //funtion for the inflicted damage on the enemy 
    public void InflictDamage(float damage, bool isExplosionDamage, GameObject damageSource)
    {

        if(health)
        {
            //how much damage is done
            var totalDamage = damage;

            // skip the crit multiplier if it's from an explosion
            if (!isExplosionDamage)
            {
                //totalDamage=totalDamage*damageMultiplier
                totalDamage *= damageMultiplier;
            }

            // potentially reduce damages if inflicted by self
            if (health.gameObject == damageSource)
            {
                //totalDamage=totalDamage*sensibilityToSelfdamage
                totalDamage *= sensibilityToSelfdamage;
            }

            // apply the damages
            health.TakeDamage(totalDamage, damageSource);
        }
    }
}
