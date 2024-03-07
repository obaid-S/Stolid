using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tpMachine : MonoBehaviour

{
    public Animator animator;
    public bool powered;
    public SceneManagerScript fade;
    
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("hasPower", powered);
    }
    
    void OnCollisionEnter2D(){
        if(powered){
            animator.SetBool("hasPower",powered);
            fade.loadScene();

        }
    }

}
