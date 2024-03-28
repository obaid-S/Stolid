using System;
using UnityEngine;
using UnityEngine.Events;

public class powerSource : MonoBehaviour
{
    // Start is called before the first frame update
    public tpMachine tp;
    public resetChar resetChar;
    public Vector2 resetLocation;
    public UnityEvent change;

    void OnTriggerEnter2D(){
        change.Invoke();
        gameObject.SetActive(false);
        tp.powered=true;
        resetChar.resetLocation=resetLocation;



    }
}
