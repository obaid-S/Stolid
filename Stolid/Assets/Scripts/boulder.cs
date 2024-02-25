
using System.Collections;
using UnityEngine;

public class boulder : MonoBehaviour
{
    public shooter shooter;
    public Movement movement;
    public bool shootNow=true;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(rockLoop());
    }
    IEnumerator rockLoop(){
        while(shootNow){
            shooter.fire();
            yield return new WaitForSeconds(.3f/movement.speedMulti);

        }
        
    }

}
