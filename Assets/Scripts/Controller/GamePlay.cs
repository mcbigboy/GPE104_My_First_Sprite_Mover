
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;
    private GameManager gm;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    void Start()
    {
        gm = GameManager.instance;

        
    }

    // Update is called once per frame
    public void UpdateMeteors()
    {
     
        
        for (int i = 0; i < gm.meteros.Count; i++)
        {
            if (gm.meteros[i] == null) 
            {
                continue; // Skip this iteration if the meteor is null
                
            }

            Meteor rock = gm.meteros[i].GetComponent<Meteor>();

            Debug.Log("meteor speed; " + rock.meteorSpeed);
            //gm.meteros[i].transform.Translate(gm.meteorPositions[i] * rock.meteorSpeed * Time.deltaTime);
            gm.meteros[i].transform.position += (Vector3)gm.meteorPositions[i] * rock.meteorSpeed * Time.deltaTime;
            WrapMeteor(gm.meteros[i]);

        }
    }

    public void WrapMeteor(GameObject metor)
    {
        Vector3 pos = metor.transform.position;
        if (pos.x > gm.meteorXlimit)
        {
            pos.x = -gm.meteorXlimit;
        }
        else if (pos.x < -gm.meteorXlimit)
        {
            pos.x = gm.meteorXlimit;
        }
        if (pos.y > gm.meteorYlimit)
        {
            pos.y = -gm.meteorYlimit;
        }
        else if (pos.y < -gm.meteorYlimit)
        {
            pos.y = gm.meteorYlimit;
        }
        metor.transform.position = pos;
    }

    public void StartGamePlay()
    {

        //GameObject.FindGameObjectWithTag("Player").SetActive(true);
        gm.ship.SetActive(true);
        for (int i = 0; i < gm.maxMeteors; i++)
        {
            do
            {
                float xSelected = Random.Range(gm.minX, gm.maxX);
                float ySelected = Random.Range(gm.minY, gm.maxY);
                gm.point = new Vector3(xSelected, ySelected, 0f);

            } while (Vector3.Distance(gm.point, gm.ship.transform.position) < 3.0f);


            gm.meteros.Add(Instantiate(gm.meteor, gm.point, gm.spawnPoint.rotation));

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            gm.meteorPositions.Add(randomDirection);
        }
    }

    public void mediumMeteor(Vector3 position)
    {
        int maxMedium = Random.Range(1, gm.maxOtherMeteors);
        for (int i = 0; i < maxMedium; i++)
        {
            GameObject newMeteor = Instantiate(gm.meteor, position, gm.spawnPoint.rotation);
            newMeteor.transform.localScale *= 0.75f;
            Meteor rock = newMeteor.GetComponent<Meteor>();
            rock.size = 2;

            gm.meteros.Add(newMeteor);

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            gm.meteorPositions.Add(randomDirection);

        }

    }

    public void smallMeteor(Vector3 position)
    {
        int maxSmall = Random.Range(1, gm.maxOtherMeteors);
        for (int i = 0; i < maxSmall; i++)
        {
            GameObject newMeteor = Instantiate(gm.meteor, position, gm.spawnPoint.rotation);
            newMeteor.transform.localScale *= 0.5f;
            Meteor rock = newMeteor.GetComponent<Meteor>();
            rock.size = 1;

            gm.meteros.Add(newMeteor);

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            gm.meteorPositions.Add(randomDirection);

        }
    }
}
