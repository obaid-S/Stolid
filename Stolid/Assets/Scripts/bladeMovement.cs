using UnityEngine;

public class bladeMovement : MonoBehaviour
{
    public Movement movement;
    private new Transform transform;
    private float pos;
    private bool goingUp;
    public float min;
    public float max;
    private float localSpeed;
    public bool droping=false;

    public AudioSource src;
    public AudioClip audioClip;
    public audioCaller audioCaller;


    void Start(){
        transform=GetComponent<Transform>();
        pos=transform.position.y;

    }
    void Update()
    {
        localSpeed=movement.power?movement.speedMulti:1;
        drop();
        
    }

    public void move(){
        if(pos<=min){
            goingUp=true;
            audioCaller.playClip(src,audioClip);
        }else if (pos>=max){

            goingUp=false;
        }

        if (goingUp){
            pos=Mathf.Clamp(min, pos + (localSpeed*2  *Time.deltaTime*10), max);
        }else{
            pos=Mathf.Clamp(min, pos - (localSpeed*2 *Time.deltaTime*10), max);
        } 

        transform.position= new Vector2(transform.position.x,pos);
    }

    public void drop(){
        if(droping){
            min=-5;
            transform.position=new Vector2(transform.position.x,max);
            localSpeed=localSpeed/3f;
            goingUp=false;
            if(min==transform.position.y){
                gameObject.SetActive(false);

            }else{
                move();
            }
        
        }else{
            move();
        }
    }
}
