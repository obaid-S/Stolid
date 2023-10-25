using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject redOrig;

    void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Jump"))
        {
            Transform player = GameObject.FindWithTag("Player").transform;
            CreateDupe(player);
        }
    }

    public void CreateDupe(Transform player)
    {
        GameObject red = Instantiate(redOrig, new Vector3(player.position.x, player.position.y, player.position.z), redOrig.transform.rotation);
    }

}
