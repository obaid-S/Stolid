using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
    public void Change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log(1);
    }
}
