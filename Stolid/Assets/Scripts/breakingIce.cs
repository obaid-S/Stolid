using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakingIce : MonoBehaviour
{   
    public callTxt ct;
    public Movement movement;
    public Animator anim;
    public Animator animTwo;
    public bladeMovement bladeMovement;
    private float temp=0;
    private int frame=0;
    private new Transform transform;



    public audioCaller audioCaller;
    public AudioSource src;
    public AudioClip audioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        transform=GetComponent<Transform>();
        movement.allowMove=false;
        StartCoroutine(waitForTxt());
    }

    // Update is called once per frame
    void Update()
    { 

        if(Input.GetKey("o")){
            if(frame<4){
                if(temp<1){
                    temp+=1f*Time.deltaTime;
                }else{
                    frame++;
                    anim.SetInteger("frame",frame);
                    temp=0;
                }
            }else if(frame==4){                
                animTwo.SetBool("water",true);
                bladeMovement.droping=true;

                audioCaller.playClip(src,audioClip);
                transform.position=new Vector2(transform.position.x+100,transform.position.y);

                frame=5;
            }

        }
    }
    IEnumerator waitForTxt(){
        yield return new WaitForSeconds(1f);
        ct.callStart();

    }
}
