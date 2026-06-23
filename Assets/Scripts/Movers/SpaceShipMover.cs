using UnityEngine;

public class SpaceShipMover : MonoBehaviour
{

    private Transform tf;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 direction, float speed, bool worldSpace)
    {

        Debug.Log("Moving in a certain direction...");
        if (worldSpace)
        {
            tf.position += direction * speed * Time.deltaTime * 20.0f;
        }
        else
        {
            tf.position += tf.TransformDirection(direction ) * speed * Time.deltaTime;
        }

        GamePlay.instance.WrapMeteor(GameManager.instance.ship);
    }

    public void Rotate(float angle)
    {
        Debug.Log("Rotating...");
        tf.Rotate(Vector3.forward * angle * Time.deltaTime); // Rotate around the Z-axis
    }

    public void Teleport(float xMin, float xMax, float yMin, float yMax)
    {
        float xSelected = Random.Range(xMin, xMax);
        float ySelected = Random.Range(yMin, yMax);

        // Teleport to a random position within a certain range
        tf.position = new Vector3(xSelected, ySelected, 0f);

               
    }
}
