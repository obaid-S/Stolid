using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class tree : MonoBehaviour

{
    public Movement movement;
    public callTxt ct;
    public Animator anim;

    private BoxCollider2D col;
    private float temp=0;
    private int frame=0;
    
    // Start is called before the first frame update
    void Start()
    {
        col=GetComponent<BoxCollider2D>();
        movement.allowMove=false;
        StartCoroutine(waitForTxt());
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("o")){
            if(frame<6){
                if(temp<1){
                temp+=1f*Time.deltaTime;
                }else{
                    frame++;
                    anim.SetInteger("frame",frame);
                    temp=0;
                    col.offset= new Vector2(0,col.offset.y+.4f);
                }
            }
        }
    }
    IEnumerator waitForTxt(){
        yield return new WaitForSeconds(1f);
        ct.callStart();

    }
    public void resetTree(){
        frame=0;
        anim.SetInteger("frame",frame);
        col.offset=new Vector2(0,-1.6f);
    }
}
