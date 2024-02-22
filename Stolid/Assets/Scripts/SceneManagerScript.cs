using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator animator;
    private string lvl;

    public void loadScene(string sceneName)
    {
        lvl=sceneName;
        animator.SetTrigger("fadeIn");  //fades screen to black 
    }

    public void nextLevel(){//called when animation ends
        animator.SetTrigger("fadeOut");
        SceneManager.LoadScene(lvl);
    }

    
    
    
    
    
}
