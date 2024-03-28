using UnityEngine;
using UnityEngine.Events;

public class rock : MonoBehaviour
{
    
    public UnityEvent hit;
    public GameObject dustPrefab;


    public audioCaller audioCaller;
    public AudioSource src;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.name=="aeinn"){
            hit.Invoke();
            Destroy(gameObject);
        }else if(collider.gameObject.name=="block_two (3)"){

            var dust=Instantiate(dustPrefab,gameObject.GetComponent<Transform>().position,gameObject.GetComponent<Transform>().rotation);
            dust.SetActive(true);


            Destroy(gameObject);
        }

        try{
            audioCaller.playClip(src,audioClip);
        }catch{}
    }

}
