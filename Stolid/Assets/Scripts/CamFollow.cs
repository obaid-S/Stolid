
using UnityEngine;

public class CamFollow : MonoBehaviour 
{
    private Transform player;
    

    private void Awake(){
        player = GameObject.FindWithTag("Player").transform;

    }

    private void LateUpdate(){
        Vector3 CameraPos= transform.position;
        CameraPos.x= Mathf.Max(player.position.x, -1);
        transform.position=CameraPos;
    }
     
}
