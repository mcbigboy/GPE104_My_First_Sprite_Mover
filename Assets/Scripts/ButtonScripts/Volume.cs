using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    public Slider volumeSlider;

    public void SetVolume(float volume)
    {
        Debug.Log("Slider changed: " + volume);
        GameManager.instance.backgroundMusic.volume = volume;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
