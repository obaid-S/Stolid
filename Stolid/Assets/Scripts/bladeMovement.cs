using UnityEngine;

public class bladeMovement : MonoBehaviour
{
    public Movement movement;
    private new Transform transform;
    public timeTutorial tt;
    private float pos;
    private bool goingUp;
    public float min;
    public float max;
    private float localSpeed;

    void Start(){
        transform=GetComponent<Transform>();
        pos=transform.position.y;
        tt.setEnabled(false);

    }
    void Update()
    {

        localSpeed=movement.power?movement.speedMulti:1;
        
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
