using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inRange;
    public int counter=0;
    public UnityEvent interactAction;


    // Update is called once per frame
    void Update()
    {
        if(inRange & counter<=1){
            interactAction.Invoke();
            counter++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider){
        inRange=true;
        counter++;
    }
    private void OnCollisionExit2D(Collision2D collider){
        inRange=false;
        counter=0;
    }

    
}
