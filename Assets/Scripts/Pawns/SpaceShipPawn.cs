using UnityEngine;

public class SpaceShipPawn : Pawn
{

    public SpaceShipMover mover;
    
    private float speed = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mover = GetComponent<SpaceShipMover>();
        
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
}
