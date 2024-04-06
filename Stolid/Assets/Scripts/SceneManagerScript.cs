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
    private static bool unmute=false;


    public audioCaller audioCaller;
    public AudioSource src;
    public AudioClip audioClip;

    public void loadScene()
    {
        animator.SetBool("fadeIn",true);  //fades screen to black 
        audioCaller.playClip(src,audioClip);
        try{
            movement.allowMove=false;
            GameObject.Find("pauseMenu").SetActive(false);
        }catch{}
        unmute=muted?false:true;
        muted=true;
        
    }
    public void fadeTxt(){
        try{
            fadeAnimat.SetBool("play",true);
        }catch{
            if(unmute){
            muted=false;
            unmute=false;
            }
            SceneManager.LoadScene(lvl);
            animator.SetBool("fadeIn",false);
        } 
    }

    public void nextLevel(){//called when animation ends
        if(unmute){
            muted=false;
            unmute=false;
        }
        fadeAnimat.SetBool("play",false);
        SceneManager.LoadScene(lvl);
        animator.SetBool("fadeIn",false);
        
    }

    public void changeMute(GameObject trigger){
        muted=trigger.GetComponent<Toggle>().isOn;
    }
}
