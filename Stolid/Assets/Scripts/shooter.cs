
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class shooter : MonoBehaviour
{
    public GameObject objPrefab;
    public Movement movement;
    public Transform location;
    public Vector2 objSpeed;


    
    public float kills;
    public UnityEvent firstKill;



    void Update(){

        if (kills<100 && kills>0){
            firstKill.Invoke();
            kills=101;
        }
    }

    public void fire(){
        var obj= Instantiate(objPrefab, location.position,location.rotation);
        obj.SetActive(true);

        StartCoroutine(updateSpeed(obj));
        
            
    }

    IEnumerator updateSpeed(GameObject obj){
        while(obj!=null){
            
            obj.GetComponent<Rigidbody2D>().velocity=objSpeed*movement.speedMulti;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
