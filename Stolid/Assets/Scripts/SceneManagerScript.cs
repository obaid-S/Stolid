using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator animator;
    public Animator fadeAnimat;
    public Movement movement;
    public string lvl;

    public void loadScene()
    {
        animator.SetBool("fadeIn",true);  //fades screen to black 
        movement.allowMove=false;
        
    }
    public void fadeTxt(){
        fadeAnimat.SetBool("play",true);
    }

    public void nextLevel(){//called when animation ends
        fadeAnimat.SetBool("play",false);
        SceneManager.LoadScene(lvl);
        animator.SetBool("fadeIn",false);
    }

    
    
    
    
    
}
