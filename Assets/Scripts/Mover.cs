using UnityEngine;

public abstract class Mover : MonoBehaviour
{

    private Transform tf;

    public float minX = -3f;
    public float maxX = 3f;

    public float minY = -3f;
    public float maxY = 3f;

    public float speed = 1f;
    public float fastSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void teleport()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
    }

}
