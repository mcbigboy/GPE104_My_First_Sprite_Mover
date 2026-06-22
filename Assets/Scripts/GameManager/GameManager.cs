using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject meteor;
    public Transform spawnPoint;
    public GameObject ship;
    public float score = 0f;

    public List<GameObject> meteros = new List<GameObject>();

    public static GameManager instance;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    public Vector3 point;

    // Game States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenObject;
    public GameObject GamePlayStateObject;
    public GameObject GameOverStateObject;

    //sound effects
    public AudioSource backgroundMusic;
    public AudioClip fireSound, bang;

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

            } while (Vector3.Distance(point, ship.transform.position) < 2.0f);


            meteros.Add(Instantiate(meteor, point, spawnPoint.rotation));
        }

        //ActivateTitleScreenState();
        ActivateState(TitleScreenStateObject);
        //Instantiate(meteor, spawnPoint.position, spawnPoint.rotation);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenObject.SetActive(false);
        GamePlayStateObject.SetActive(false);
        GameOverStateObject.SetActive(false);
    }

    /*
    public void ActivateTitleScreenState()
    {
        DeactivateAllStates();
        TitleScreenStateObject.SetActive(true);
    }

    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsScreenState()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
    }

    public void ActivateCreditsScreenState()
    {
        DeactivateAllStates();
        CreditsScreenObject.SetActive(true);
    }

    public void ActivateGamePlayState()
    {
        DeactivateAllStates();
        GamePlayStateObject.SetActive(true);

        // Doing anything else that needs to be done when the game play state is activated, such as resetting the score, lives, etc.
        // Spawning the player ship, resetting the position of the meteors, etc.
    }

    public void ActivateGameOverState()
    {
        DeactivateAllStates();
        GameOverStateObject.SetActive(true);
    }
    */
    public void ActivateState(GameObject gameObject)
    {
        DeactivateAllStates();
        gameObject.SetActive(true);

        if( gameObject == GamePlayStateObject)
        {
            // Doing anything else that needs to be done when the game play state is activated, such as resetting the score, lives, etc.
            // Spawning the player ship, resetting the position of the meteors, etc.
        } 

    }


}
