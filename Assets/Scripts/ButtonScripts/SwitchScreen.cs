using UnityEngine;

public class SwitchScreen : MonoBehaviour
{
    public void SwitchToMainMenu()
    {
        GameManager.instance.ActivateState(GameManager.instance.MainMenuStateObject);
    }

    public void SwitchToOptions()
    {
        GameManager.instance.ActivateState(GameManager.instance.OptionsScreenStateObject);
    }

    public void SwitchToCredits()
    {
        GameManager.instance.ActivateState(GameManager.instance.CreditsScreenObject);
    }

    public void SwitchToGamePlay()
    {
        GameManager.instance.ActivateState(GameManager.instance.GamePlayStateObject);
        //GameManager.instance.gamePlay.StartGamePlay();
        GamePlay.instance.StartGamePlay();
    }

    public void SwitchToGameOver()
    {
        GameManager.instance.ActivateState(GameManager.instance.GameOverStateObject);

    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
