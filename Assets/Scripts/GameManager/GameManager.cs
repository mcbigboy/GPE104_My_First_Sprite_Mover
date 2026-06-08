using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject meteor;
    public Transform spawnPoint;
    public GameObject ship;

    public List<GameObject> meteros = new List<GameObject>();

    public static GameManager instance;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    public Vector3 point;

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
        for(int i = 0; i < 5; i++)
        {
            do {
                float xSelected = Random.Range(minX, maxX);
                float ySelected = Random.Range(minY, maxY);
                point = new Vector3(xSelected, ySelected, 0f);

            } while (Vector3.Distance(point, ship.transform.position) < 1.0f);


            meteros.Add(Instantiate(meteor, point, spawnPoint.rotation));
        }
        //Instantiate(meteor, spawnPoint.position, spawnPoint.rotation);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
