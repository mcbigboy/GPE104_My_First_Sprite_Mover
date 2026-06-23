using UnityEngine;

public class DeathMeteor : Death
{
    // 3 large, 2 medium, 1 small
    public int largePoints;
    public int mediumPoints;
    public int smallPoints;

    private Vector3 meteroPosition;
    Meteor rock;

    public override void Die()
    {
        GameManager.instance.backgroundMusic.PlayOneShot(GameManager.instance.bang);
        int index = GameManager.instance.meteros.IndexOf(gameObject);
        if (index >= 0)
        {
            rock = GameManager.instance.meteros[index].GetComponent<Meteor>();
            meteroPosition = gameObject.transform.position;
            GameManager.instance.meteros.RemoveAt(index);
            GameManager.instance.meteorPositions.RemoveAt(index);
        }

        Destroy(gameObject);
        
        Debug.Log("Metero: " + GameManager.instance.meteros.Count);

        if (rock.size == 3)
        {
            rock.size = 2;
            GameManager.instance.score += largePoints;
            GamePlay.instance.mediumMeteor(meteroPosition);
            GameManager.instance.largeMeteorDestroyed++;
        }

        if (rock.size == 2)
        {
            rock.size = 1;
            GameManager.instance.score += mediumPoints;
            GamePlay.instance.smallMeteor(meteroPosition);
            GameManager.instance.mediumMeteorDestroyed++;
        }

        if(rock.size == 1) 
        {
            GameManager.instance.score += smallPoints;
            GameManager.instance.smallMeteorDestroyed++;

        }
        
        if(GameManager.instance.meteros.Count == 0)
        {
            GameManager.instance.lossORwin = true;
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
