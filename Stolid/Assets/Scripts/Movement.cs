
using UnityEngine;

public class Movement : MonoBehaviour
{
    private new Rigidbody2D rigidbody; 

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 15f;
    public float jumpHeight= 5f;

    public bool grounded {get; private set;}
    public bool jumping {get; private set;}

    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update(){
        HorizontalMovement();
    }

    private void HorizontalMovement(){
        inputAxis= Input.GetAxis("Horizontal");
    
        
        velocity.x=inputAxis*moveSpeed;
    }

    private void FixedUpdate(){
        Vector2 position = rigidbody.position;
        position += velocity*Time.fixedDeltaTime;

        position.x=Mathf.Max(position.x,-1);

        rigidbody.MovePosition(position);


    }

}
