using UnityEngine;

public abstract class Health : MonoBehaviour
{

    public float health;
    public float maxHealth;
    protected float startingHealth;
    public bool instantDeath = false; // If true, any damage will kill the entity immediately


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingHealth = health;
    }

    public abstract void TakeDamage(float damage);
    public abstract void Heal(float healAmount);

    public abstract void resetHealth();
  
    public abstract void die();

    public abstract bool isAlive();

    

}
