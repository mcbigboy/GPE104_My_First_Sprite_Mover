using UnityEngine;

public class AsteroidHum : MonoBehaviour
{
    public Transform player;
    private AudioSource humSource;

    private float lastDistance;

    void Start()
    {
        humSource = GetComponent<AudioSource>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        lastDistance = Vector3.Distance(transform.position, player.position);
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, player.position);

        if (currentDistance < lastDistance)
        {
            humSource.pitch = 1.2f; // getting closer
        }
        else if (currentDistance > lastDistance)
        {
            humSource.pitch = 0.8f; // moving away
        }
        else
        {
            humSource.pitch = 1f;
        }

        lastDistance = currentDistance;
    }
}
