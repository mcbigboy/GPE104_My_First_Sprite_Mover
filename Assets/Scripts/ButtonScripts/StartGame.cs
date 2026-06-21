using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void StartTheGame()
    {
       if (GameManager.instance != null)
        {
            GameManager.instance.ActivateState(GameManager.instance.MainMenuStateObject);
        }
        
        
    }                   
}
