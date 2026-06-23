using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Controller
{
    // Teleport key
    public KeyCode teleportKey;

    // Local space movement keys
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode rotateClockwise;
    public KeyCode rotateCounterclockwise;

    // World space movement keys
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveLeft;
    public KeyCode moveRight;

    // Turbo speed keys
    public KeyCode turbo1;
    public KeyCode turbo2;

    // Quit key
    public KeyCode quitKey;

    // Fire bullet key
    public KeyCode fire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MakeDecisions();
    } 
    
    public override void MakeDecisions()
    {
        if(Input.GetKeyDown(teleportKey))
        {
            Debug.Log("Teleporting...");
            pawn.Teleport();
        }

        if (Input.GetKey(moveForward))
        {
            Debug.Log("Moving forward...");
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackward))
        {
            Debug.Log("Moving backward...");
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwise))
        {
            Debug.Log("Rotating clockwise...");
            pawn.RotateClockwise();
        }

         if(Input.GetKey(rotateCounterclockwise))
        {
            Debug.Log("Rotating counterclockwise...");
            pawn.RotateCounterClockwise();
        } 

         if(Input.GetKeyDown(moveUp))
        {
            Debug.Log("Moving up...");
            pawn.MoveUp();
        }
        
        if (Input.GetKeyDown(moveDown))
        {
            Debug.Log("Moving down...");
            pawn.MoveDown();
        }
        
        if (Input.GetKeyDown(moveLeft))
        {
            Debug.Log("Moving left...");
            pawn.MoveLeft();
        }
        
        if (Input.GetKeyDown(moveRight))
        {
            Debug.Log("Moving right...");
            pawn.MoveRight();
        }
        
        if (Input.GetKey(turbo1) || Input.GetKey(turbo2))
        {
            Debug.Log("Activating turbo ...");
            pawn.isTurboActive = true;
        }
        else
        {
            pawn.isTurboActive = false;
        }

        if (Input.GetKeyDown(quitKey))
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }
       
        if (Input.GetMouseButtonDown(0))
        {
           
            if (GameManager.instance.GamePlayStateObject.activeSelf)
            {
               pawn.Fire(); 
            }
            
        }

        if(Input.GetMouseButton(0))
        {
            if (GameManager.instance.GamePlayStateObject.activeSelf)
            {
                pawn.FireMore();
            }
        }
    }
}
