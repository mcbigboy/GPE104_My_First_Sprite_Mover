using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + GameManager.instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score.ToString();
    }
}
