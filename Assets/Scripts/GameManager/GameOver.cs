using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI lossORwin;
    public TextMeshProUGUI stats;


    GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Final Score: " + gm.score.ToString();
        lossORwin.text = gm.lossORwin ? "YOU WIN!!" : "YOU LOSSET!!";

        int totalDestroyed = gm.largeMeteorDestroyed + gm.mediumMeteorDestroyed + gm.smallMeteorDestroyed;

        stats.text = "Total Meteors Destroyed: " + totalDestroyed + 
            "\nLarge: " + gm.largeMeteorDestroyed +
            "\nMedium: " + gm.mediumMeteorDestroyed +
            "\nSmall: " + gm.smallMeteorDestroyed;






    }
}
