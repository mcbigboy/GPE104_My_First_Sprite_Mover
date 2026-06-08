using UnityEngine;

public class MetorHealth : Health
{
    public override void die()
    {

        DeathMeteor deathComponent = GetComponent<DeathMeteor>();
        if (deathComponent != null)
        {
            deathComponent.Die();
        }
        Destroy(this);
    }

    public override void Heal(float healAmount)
    {
        // not needed for meteors, they don't heal
    }

    public override bool isAlive()
    {
        if(health == 0)
        {
            return false;
        }
        return true;
    }

    public override void resetHealth()
    {
        // not needed for meteors, they don't reset health
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("Meteor destroyed!"); 
            die();
        }   
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
