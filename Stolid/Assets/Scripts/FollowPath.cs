using UnityEngine;
using UnityEngine.UIElements;

public class FollowPath : MonoBehaviour
{
    public GameObject redOrig;

    void Start()
    {
         
    }
    public void Update()
    {
        bool temp = false;//CHANGE TO TRUE TO SEE THE BUTTON PRESS
        if (Input.GetButtonDown("Jump") && temp==true )
        {
            Transform player = GameObject.FindWithTag("Player").transform;
            CreateDupe(player);
        }
    }

    public void CreateDupe(Transform player)
    {

        GameObject red = Instantiate(redOrig, new Vector3(player.position.x, player.position.y - 1.25f, player.position.z), redOrig.transform.rotation);
    }

}

