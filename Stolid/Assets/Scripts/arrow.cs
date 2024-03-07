using UnityEngine;
using UnityEngine.Events;

public class arrow : MonoBehaviour
{
    public UnityEvent hit;
    public UnityEvent hitTwo;

    public shooter shooter;    
    public tpMachine tp;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.name=="aeinn" ){
            if (!tp.powered){
                hit.Invoke();
                shooter.eventKills=shooter.eventKills>=1? 2:1;
            }else{
                hit.Invoke();
            }
        
        }else if(collider.gameObject.name=="boulder_fall"||collider.gameObject.name=="boulder_fall (1)"){
            Destroy(gameObject,2);
        }


        

    }
    
}
