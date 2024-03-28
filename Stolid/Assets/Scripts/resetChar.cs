using UnityEngine;

public class resetChar : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private new Rigidbody2D rigidbody;
    public GameObject player;
    public Vector2 resetLocation;
    public Movement movement;


    public audioCaller audioCaller;
    public AudioSource src;
    public AudioClip audioClip;

    public void startReset(){
        audioCaller.playClip(src,audioClip);

        movement.allowMove=false;
        rigidbody=player.GetComponent<Rigidbody2D>();
        rigidbody.position=resetLocation;
        animator.SetTrigger("play");

    }

    public void endMove(){
        movement.allowMove=true;
    }
}
