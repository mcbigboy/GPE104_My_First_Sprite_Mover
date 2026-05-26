using UnityEngine;

public abstract class Mover : MonoBehaviour
{

    private Transform tf;
    public float minX = -3f;
    public float maxX = 3f;

    public float minY = -3f;
    public float maxY = 3f;

    public float moveSpeed = 1f;
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

    public virtual void teleport()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        transform.position = new Vector3(randomX, randomY, 0.0F);
    }

    public virtual void move(float horizontal, float vertical, float speed)
    {
        Vector3 direction = new Vector3(horizontal, vertical, 0f);

        transform.position += transform.TransformDirection(direction) * speed * Time.deltaTime;

    }

    public virtual void moveWorld(float horizontal, float vertical, float speed)
    {
        transform.position += new Vector3(horizontal, vertical, 0f) * speed * Time.deltaTime;
    }

    public virtual void rotate(float angle)
    {
        transform.Rotate(Vector3.forward * angle * Time.deltaTime);
    }
}
