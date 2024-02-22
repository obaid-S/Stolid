using UnityEngine;

public class bladeMovement : MonoBehaviour
{
    private new Transform transform;
    public float speedMulti;
    private float pos;
    private bool goingUp;
    public float min;
    public float max;
    
    public Movement movement;
    void Start(){
        transform=GetComponent<Transform>();
        pos=transform.position.y;

    }
    void Update()
    {
        speedMulti= (float)(movement.timeControlSpeed>=0? (movement.timeControlSpeed*.95)+1 : 1-(Mathf.Abs(movement.timeControlSpeed)*.95)); //change the *num to change speed of time
        
        if(pos<=min){
            goingUp=true;
        }else if (pos>=max){
            goingUp=false;
        }

        if (goingUp){
            pos=Mathf.Clamp(min, (float)(pos + (0.1 * speedMulti)), max);
        }else{
            pos=Mathf.Clamp(min, (float)(pos - (0.1 * speedMulti)), max);
        }
        

        transform.position= new Vector2(transform.position.x,pos);
    }
}
