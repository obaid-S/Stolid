using UnityEngine;

public class bladeMovement : MonoBehaviour
{
    public Movement movement;
    public clock_Interaction clockStatus;
    private new Transform transform;
    private float pos;
    private bool goingUp;
    public float min;
    public float max;
    private float localSpeed;

    void Start(){
        transform=GetComponent<Transform>();
        pos=transform.position.y;

    }
    void Update()
    {

        localSpeed=clockStatus.animator.GetBool("pickedUp")?movement.speedMulti:1;
        Debug.Log(localSpeed);
        Debug.Log(clockStatus.animator.GetBool("pickedUp"));
        
         if(pos<=min){
             goingUp=true;
         }else if (pos>=max){
             goingUp=false;
         }

        if (goingUp){
             pos=Mathf.Clamp(min, pos + (0.1f *localSpeed ), max);
         }else{
             pos=Mathf.Clamp(min, pos - (0.1f * localSpeed), max);
         } 

        
        
        

        transform.position= new Vector2(transform.position.x,pos);
    }
}
