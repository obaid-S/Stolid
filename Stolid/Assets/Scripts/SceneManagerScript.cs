using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public Animator animator;
    public Animator fadeAnimat;
    public Movement movement;
    public string lvl;

    public void loadScene()
    {
        animator.SetBool("fadeIn",true);  //fades screen to black 
        try{
            movement.allowMove=false;
        }catch{
            var buttons=GameObject.Find("buttons");
            buttons.SetActive(false);
        }
        
    }
    public void fadeTxt(){
        try{
            fadeAnimat.SetBool("play",true);
        }catch{
            SceneManager.LoadScene(lvl);
            animator.SetBool("fadeIn",false);
        }
    }

    public void nextLevel(){//called when animation ends
        fadeAnimat.SetBool("play",false);
        SceneManager.LoadScene(lvl);
        animator.SetBool("fadeIn",false);
    }

    
    
    
    
    
}
