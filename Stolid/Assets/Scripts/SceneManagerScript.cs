using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public Animator animator;
    public Animator fadeAnimat;
    public Movement movement;
    public string lvl;
    public static bool muted;

    public void loadScene()
    {
        animator.SetBool("fadeIn",true);  //fades screen to black 
        try{
            GameObject.Find("pauseMenu").SetActive(false);
            movement.allowMove=false;
        }catch{}

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

    public void changeMute(GameObject trigger){
        muted=trigger.GetComponent<Toggle>().isOn;
    }
}
