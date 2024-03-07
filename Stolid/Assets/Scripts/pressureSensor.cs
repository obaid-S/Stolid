using System.Collections;
using UnityEngine;

public class pressureSensor : MonoBehaviour
{  
    public Movement movement;
    public shooter shooter;
    public callTxt ct;

    private bool startShoot = false;
    private bool newBullet=true;
    // Start is called before the first frame update
    void Start()
    {
        movement.allowMove=false;
        StartCoroutine(waitForTxt());
    }

    void Update(){

         if(startShoot && newBullet)
         {
            newBullet=false;
            StartCoroutine(waitForBullet());

         }
       
    }
   

    IEnumerator waitForTxt(){
        yield return new WaitForSeconds(1f);
        ct.callStart();

    }
    IEnumerator waitForBullet(){
        shooter.fire();
        yield return new WaitForSeconds(3.2f-(1.5f*movement.speedMulti));
        newBullet=true;

    }
    

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name != "block_two (3)"){
            startShoot=true;
            newBullet=true;
        }
        

        
    }
    void OnTriggerExit2D(){
        startShoot=false;
    }
}
