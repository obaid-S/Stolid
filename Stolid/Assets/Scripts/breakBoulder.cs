using Unity.VisualScripting;
using UnityEngine;

public class breakBoulder : MonoBehaviour
{
    public GameObject outerShell;
    public GameObject innerShell;
    public GameObject dustPrefab;
    public int dmg;

    public GameObject dmgPart;
    public Animator anim;
    
    // Start is called before the first frame update
    void Update(){
        if(dmg<=0){
            var temp=0;
            while(temp<20){
                var dust=Instantiate(dustPrefab,new Vector3(outerShell.transform.position.x+Random.Range(-3,4),outerShell.transform.position.y-Random.Range(-2,3),0),outerShell.GetComponent<Transform>().rotation);
                dust.SetActive(true);
                temp++;
            }
            anim.SetInteger("frame",0);
            Destroy(outerShell);
            Destroy(innerShell);
            
        }else{
            if (dmg%2==0){
                anim.SetInteger("frame",8-(dmg/2));
            }
        }
    
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.name=="arrow0(Clone)" & Input.GetKey("o")){
            
            dmg--;
        }
    }

    
}
