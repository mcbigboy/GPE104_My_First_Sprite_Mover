using UnityEngine;

public abstract class Pawn : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float rotationSpeed = 10.0f; // Degrees per second
    public float moveSpeed = 2.0f; // Units per second
    public float turboSpeed = 3.0f; // Units per second when turbo is active
    public bool isTurboActive = false;

    void Start()
    {
       
    }   

    public abstract void MoveForward();

    public abstract void MoveBackward();

    public abstract void RotateClockwise();

    public abstract void RotateCounterClockwise();

    public abstract void MoveUp();

    public abstract void MoveDown();
    
    public abstract void MoveLeft();

    public  abstract void MoveRight();

    public abstract void Teleport();    

}
