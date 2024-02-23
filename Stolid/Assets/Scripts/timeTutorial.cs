using UnityEngine;

public class timeTutorial : MonoBehaviour
{
    public Animator animator;
   
    void Update(){
        Debug.Log("test");
        if(animator.GetFloat("next")==1 & Input.GetAxis("timeSpeed")>0.3){
            animator.SetFloat("next",2);
        }else if(animator.GetFloat("next")==2 & Input.GetAxis("timeSpeed")<-.3)
        {
            animator.SetFloat("next",3);
        }

    }
    public void startAnim(){
        animator.SetFloat("next",1);
    }
   
    public void setEnabled(bool trueOrFalse){
        enabled=trueOrFalse;
    }

    
}
