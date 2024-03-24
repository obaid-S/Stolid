using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject buttons;
    public Movement movement;
    public audioCaller audioCaller;

    private int ranTimes=0;
    private bool pauseScreenOpen=false;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            toggleMenu();
        }
    }

    public void toggleMenu(){
        pauseScreenOpen= buttons.activeSelf ? true:false;//toggle between off n on
            if(!pauseScreenOpen && ranTimes==0){
                runOnce();
                ranTimes = 1;
                audioCaller.src.Pause();
            }else{
                runOnce();
                ranTimes=0;
                audioCaller.src.Play();
            }   
    }

    private void runOnce(){
        buttons.SetActive(!pauseScreenOpen);//toggle between off n on
        movement.allowMove=pauseScreenOpen;
    }
}
