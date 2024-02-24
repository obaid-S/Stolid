
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform location;
    public float arrowSpeed;
    public Movement movement;

    public void fire(){
        var arrow= Instantiate(arrowPrefab, location.position,location.rotation);
        arrow.SetActive(true);
        arrow.GetComponent<Rigidbody2D>().velocity=new Vector2 (-arrowSpeed* (2*movement.speedMulti),0f);
        
        StartCoroutine(updateSpeed(arrow));
        
            
    }
    IEnumerator updateSpeed(GameObject arrow){
        while(arrow!=null){
            arrow.GetComponent<Rigidbody2D>().velocity=new Vector2 (-arrowSpeed* (2*movement.speedMulti),0f);
            yield return new WaitForSeconds(0.2f);
            Debug.Log(Time.frameCount);
        }
    }
}
