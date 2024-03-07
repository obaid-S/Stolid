using UnityEngine;

public class powerSource : MonoBehaviour
{
    // Start is called before the first frame update
    public tpMachine tp;
    public boulder boulder;

    public resetChar resetChar;
    public shooter shooter;


    void OnTriggerEnter2D(){
        gameObject.SetActive(false);
        tp.powered=true;
        boulder.drop=true;
        resetChar.resetLocation=new Vector2(13.5f,1);
        shooter.eventKills=3;

    }
}
