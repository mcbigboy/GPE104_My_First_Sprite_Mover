using UnityEngine;

public class BulletMover : MonoBehaviour
{

    public float speed = 1.0f; // Speed of the bullet
    public Rigidbody2D rb; // Reference to the Rigidbody2D component

    public GameObject impactEffect; // Effect to instantiate on impact

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.up * speed; // Move the bullet in the direction it is facing

    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet collided with: " + other.gameObject.name);
        Debug.Log(other.name);
        Debug.Log(other.GetType());
        Debug.Log(other.gameObject.tag);

        other.gameObject.GetComponent<MetorHealth>().TakeDamage(60); // Apply damage to the meteor if it has a MetorHealth component
        

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

       
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroy the bullet when it goes off-screen
    } 
}
