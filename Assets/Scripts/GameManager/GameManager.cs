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
    public List<Vector2> meteorPositions = new List<Vector2>();
    public int maxMeteors = 8;
    public int minMeteors = 5;
    public int maxOtherMeteors = 3;
    public float largeMeteorDamage = 30f;
    public float mediumMeteorDamage = 20f;
    public float smallMeteorDamage = 10f;

    public bool lossORwin = false;
    public int largeMeteorDestroyed = 0;
    public int mediumMeteorDestroyed = 0;
    public int smallMeteorDestroyed = 0;

    public float minMeteorSpeed = 3;
    public float maxMeteorSpeed = 6f;
    public float meteorXlimit = 10f;
    public float meteorYlimit = 5f;

    public static GameManager instance;
    public GamePlay gamePlay;

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
        
        gamePlay = GamePlay.instance;
    }   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        //ActivateTitleScreenState();
        ActivateState(TitleScreenStateObject);
        //Instantiate(meteor, spawnPoint.position, spawnPoint.rotation);    
    }

    // Update is called once per frame
    void Update()
    {
        if(GamePlayStateObject.activeSelf)
        {
            gamePlay.UpdateMeteors();
        }
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
