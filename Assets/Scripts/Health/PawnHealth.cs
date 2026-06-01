using UnityEngine;

public class PawnHealth : Health
{
    public override void die()
    {
        DeathDestroy deathComponent = GetComponent<DeathDestroy>();
        if (deathComponent != null)
        {
            deathComponent.Die();
        }
    }

    public override void Heal(float healAmount)
    {
        health += healAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        };
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
        health = startingHealth;
    }

    public override void TakeDamage(float damage)
    {

        if (instantDeath)
        {
            health = 0;
            die();
            return;
        }

        health -= damage;
        if(health <= 0)
        {
            health = 0;
            die();
        }
    }

  
}
