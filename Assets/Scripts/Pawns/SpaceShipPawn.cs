using Unity.VisualScripting;
using UnityEngine;

public class SpaceShipPawn : Pawn
{

    public SpaceShipMover mover;
    
    private float speed = 0.0f;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   

    // fire point
    public GameObject bulletToFire;
    public Transform firePoint;
    public float timeBetweenShots = 0.2f;
    private float shotCounter;

    Health health;
    public RectTransform rect;
    private bool isDead = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mover = GetComponent<SpaceShipMover>();
        health = GetComponent<Health>();

        rect = health.liveBarImage.GetComponent<RectTransform>();

        rect.sizeDelta = new Vector2(health.liveImageWidth * health.maxLives, rect.sizeDelta.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (isTurboActive)
        {
            speed = moveSpeed * turboSpeed;
        }
        else
        {
            speed = moveSpeed;
        }
        

    }

    public override void MoveForward()
    {
        if (mover != null)
        {
            Debug.Log("Moving forward...");
            
            mover.Move(Vector3.up, speed, false);
        }
    }

    public override void MoveBackward()
    {
        if (mover != null)
        {
            
            mover.Move(Vector3.down, speed, false);
        }
    }

    public override void RotateClockwise()
    {
        if (mover != null)
        {
            
            mover.Rotate(90 * rotationSpeed); // Rotate around the Z-axis
        }
    }

    public override void RotateCounterClockwise()
    {
        if (mover != null)
        {
            mover.Rotate(-90 * rotationSpeed); // Rotate around the Z-axis in the opposite direction
        }
    }

    public override void MoveUp()
    {
        if (mover != null)
        {
            mover.Move(Vector3.up, speed, true);
        }
    }

    public override void MoveDown()
    {
        if (mover != null)
        {
            mover.Move(Vector3.down, speed, true);
        }
    }

    public override void MoveLeft()
    {
        if (mover != null)
        {
            mover.Move(Vector3.left, speed, true);
        }
    }

    public override void MoveRight()
    {
        if (mover != null)
        {
            mover.Move(Vector3.right, speed, true);
        }
    }

    public override void Teleport()
    {
        Debug.Log("Teleporting to a random position within the defined bounds...");
        if (mover != null)
        {
            mover.Teleport(minX, maxX, minY, maxY);
        }
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("The GameObject of the other object is named: " + otherObject.gameObject.name);

        if (otherObject.gameObject.name != "bullet_0") 
        { 
            
            

            if (health != null) {

                if (health.instantDeath)
                {
                    health.die();
                    return;
                }

                Meteor meteor = otherObject.gameObject.GetComponent<Meteor>();

                if (meteor != null && !isDead)
                {
                    health.TakeDamage(meteor.GetDamage());
                    health.healthBarImage.fillAmount = (float)health.health / health.maxHealth;
                }
                Debug.Log("Current Lives before die: " + health.currentLives);
                if (health.health <= 0 && !isDead)
                {
                    isDead = true;
                    health.currentLives--;
                    GameManager.instance.ship.SetActive(false);
                    
                    rect.sizeDelta = new Vector2(health.liveImageWidth * health.currentLives, rect.sizeDelta.y);

                    if (health.currentLives < 0)
                    {
                        health.die();
                    }

                    RespawnShip();
                }
            }
        }
    }

    public override void Fire()
    {
        Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
        shotCounter = timeBetweenShots;
       //sfxSource.PlayOneShot(GameManager.instance.fireSound);
        GameManager.instance.backgroundMusic.PlayOneShot(GameManager.instance.fireSound);
    }

    public override void FireMore()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            shotCounter = timeBetweenShots;
            GameManager.instance.backgroundMusic.PlayOneShot(GameManager.instance.fireSound);
        }
    }

    public override void RespawnShip()
    {
        health.resetHealth();
        GameManager.instance.ship.SetActive(true);
        isDead = false;
    }
}
