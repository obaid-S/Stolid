using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
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
        yield return new WaitForSeconds(1f );
        ct.callStart();

    }
    IEnumerator waitForBullet(){
        shooter.fire();
        yield return new WaitForSeconds(5-(2*movement.speedMulti));
        newBullet=true;

    }
    

    void OnCollisionEnter2D(){
        startShoot=true;
        newBullet=true;

        
    }
    void OnCollisionExit2D(){
        startShoot=false;
    }
}
