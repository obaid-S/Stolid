using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class endLinesCnrl : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public SceneManagerScript sceneManagerScript;
    
    public void playNextSequence(){
        animator.SetBool("play",true);
    }

    void Update(){
        if (Input.GetButtonDown("Submit")){
            try{
                sceneManagerScript.loadScene();
            }catch{}
        }
    }
}
