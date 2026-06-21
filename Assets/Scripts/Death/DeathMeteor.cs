using UnityEngine;

public class DeathMeteor : Death
{

    public int points;

    public override void Die()
    {
        GameManager.instance.meteros.Remove(gameObject);
        Destroy(gameObject);
        GameManager.instance.score += points;
        Debug.Log("Metero: " + GameManager.instance.meteros.Count);
        if(GameManager.instance.meteros.Count == 0)
        {
            GameManager.instance.ActivateState(GameManager.instance.GameOverStateObject);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Meteor collided with: " + other.gameObject.name);
        if (other.gameObject.name == "starShip_0")
        {
            Debug.Log("Player hit by meteor!");
            other.GetComponent<DeathDestroy>().Die();
            Die();
            
        }
    }
}
