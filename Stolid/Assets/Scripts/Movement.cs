
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    private new Rigidbody2D rigidbody;
    private BoxCollider2D col;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 15f;

    public float jumpForce = 5f;
    public bool grounded {get; private set;}
    public bool jumping {get; private set;}

    public float gravity = 10f;




    

    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }
    
    private void Update(){
        grounded= col.Raycast(Vector2.down);
        HorizontalMovement();
        if (grounded)
        {
            VerticalMovement();
        }
        ApplyGravity();
        
        
        
    }

    private void HorizontalMovement(){
        inputAxis= Input.GetAxis("Horizontal");

        velocity.x=inputAxis*moveSpeed;
        if (velocity.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (velocity.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (col.Raycast(Vector2.right * velocity.x))
        {
            velocity.x = 0f;
        }
    }

    private void VerticalMovement()
    {
        velocity.y= Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;

        if (Input.GetButtonDown("Jump") && grounded)
        {


            if (col.Raycast(Vector2.up))
            {
                velocity.y = 0f;
            }
            else
            {
                velocity.y = jumpForce;
                jumping = true;
            }
            
        }

        
    }

    private void ApplyGravity()
    {
        //if velocity is negative OR if the jump button isnt being held, second part is to make jump last logner if held
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");

        float multiplier = falling ? 2f : 1f;

        velocity.y -= gravity * Time.deltaTime * multiplier;
        

    }

    private void FixedUpdate(){
        Vector2 position = rigidbody.position;
        position += velocity*Time.fixedDeltaTime;

        position.x=Mathf.Max(position.x,-1);

        rigidbody.MovePosition(position);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (col.Raycast(Vector2.up))
            {
                velocity.y = 0f;
            }
            
        } 
    }
}
