using UnityEngine;

public class TitileSceen : MonoBehaviour
{
    public void ToTitileScreen()
    {
        GameManager.instance.ActivateState(GameManager.instance.TitleScreenStateObject);
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
