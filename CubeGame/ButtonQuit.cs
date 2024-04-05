using UnityEngine;

public class ButtonQuit : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("QUITING GAME");
        Application.Quit(); 
    }
}
