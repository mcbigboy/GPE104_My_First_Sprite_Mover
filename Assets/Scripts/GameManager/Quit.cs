using UnityEngine;

public class Quit : MonoBehaviour
{
 public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }   
}
