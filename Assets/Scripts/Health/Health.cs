using UnityEngine;
using UnityEngine.UI;


public abstract class Health : MonoBehaviour
{

    public float health;
    public float maxHealth;
    protected float startingHealth;
    public bool instantDeath = false; // If true, any damage will kill the entity immediately
    public Image healthBarImage;
    public int maxLives = 3; // Maximum number of lives
    public int currentLives; // Current number of lives`
    public float liveImageWidth = 32.0f; // Width of the live image
    public Image liveBarImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingHealth = health;
        currentLives = maxLives; // Initialize current lives to maximum at the start

    }

    public abstract void TakeDamage(float damage);
    public abstract void Heal(float healAmount);

    public abstract void resetHealth();
  
    public abstract void die();

    public abstract bool isAlive();

    

}
