using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class back : MonoBehaviour
{
    public int page;
    public SceneManagerScript sceneManagerScript;


    public void ExitPage(){
        if (page==0){
            Application.Quit();
        }else if(page==1){
            sceneManagerScript.loadScene();
        }
    }
}


