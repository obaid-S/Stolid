using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTxt : MonoBehaviour
{
    public callTxt ct;
    public Movement movement;
    public float secs=1f;
    // Start is called before the first frame update
    void Start()
    {
        movement.allowMove=false;
        StartCoroutine(waitForTxt());
    }

    // Update is called once per frame
    IEnumerator waitForTxt(){
        yield return new WaitForSeconds(secs);
        ct.callStart();

    }
}
