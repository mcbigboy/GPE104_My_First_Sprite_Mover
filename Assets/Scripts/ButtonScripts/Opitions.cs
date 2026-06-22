using UnityEngine;

public class Opitions : MonoBehaviour
{
    public void OpitionsState()
    {
        GameManager.instance.ActivateState(GameManager.instance.OptionsScreenStateObject);
    }
}
