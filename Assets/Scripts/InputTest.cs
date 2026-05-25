using UnityEngine;

 
public class InputTest : MonoBehaviour
{
    private Transform tf;
    public float minX = -3f;
    public float maxX = 3f;

    public float minY = -3f;
    public float maxY = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Debug.Log("RandX: " + randomX + ", RandY: " + randomY);

            tf.position = new Vector3(randomX, randomY, tf.position.z);

        }

    }
}
