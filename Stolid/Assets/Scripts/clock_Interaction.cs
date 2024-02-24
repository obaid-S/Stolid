using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class clock_Interaction : MonoBehaviour
{
    private new Transform transform;
    public timeTutorial tt;
    public  Movement movement;
    private Vector2 temp=new Vector2(1,1);
    public Vector2 endLocation;
    public Animator animator;

    void Update()
    {
        animator.SetFloat("timeControlSpeed",movement.speedMulti);
        if( movement.power ){
            animator.SetBool("pickedUp",true);
        }

        
    }

    public void startClock(){
        transform=GetComponent<Transform>();
        StartCoroutine(moveClock());
    }

    IEnumerator moveClock(){

        while ((Vector2)transform.position!=endLocation || (Vector2)transform.localScale!= temp){
            transform.localScale=Vector2.MoveTowards(transform.localScale,temp,0.003f);
            transform.position=Vector2.MoveTowards(transform.position,endLocation,0.03f);
            yield return null;
        }
        movement.power=true;
        tt.setEnabled(true);
        tt.startAnim();
    }
}

