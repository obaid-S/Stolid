using UnityEngine;
using UnityEngine.Events;

public class arrow : MonoBehaviour
{
    public UnityEvent hit;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.name=="aeinn"){
            hit.Invoke();
            Destroy(gameObject);
        }

    }
    
}
