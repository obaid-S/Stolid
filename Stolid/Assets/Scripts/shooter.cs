
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


    
    public float eventKills;
    public UnityEvent firstKill;
    public UnityEvent secKill;




    void Update(){

        if (eventKills==1){
            firstKill.Invoke();
            eventKills++;
        }else if (eventKills==3){
            movement.allowMove=false;
            StartCoroutine(waitSec());
            eventKills++;
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
    IEnumerator waitSec(){
        yield return new WaitForSeconds(1f);
        secKill.Invoke();
    }
}
