using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int size = 3; // 3 large, 2 medium, 1 small
    public float meteorSpeed;
    private GameManager gm;

    void Start()
    {
        gm = GameManager.instance;
        meteorSpeed = Random.Range(gm.minMeteorSpeed, gm.maxMeteorSpeed);
    }        
            
    public float GetDamage()
    {
        if (size == 3) return gm.largeMeteorDamage;
        if (size == 2) return gm.mediumMeteorDamage;
        return gm.smallMeteorDamage;
    }
}
