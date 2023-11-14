
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    private new Rigidbody2D rigidbody;
    private BoxCollider2D col;

    private Vector2 velocity;
    private float inputAxis;
    public float moveSpeed = 25f;
 
    

    public float jumpForce = 30f;
    public bool grounded {get; private set;}
    public bool jumping {get; private set;}

    //delay accepted b4 jump input
    public float jumpDelay = 1f;
    private float jumpDelayCounter =10f;

    //delay accepted b4 jump buffer
    public float jumpBuffer = 1f;
    private float jumpBufferCounter = 0f;

    public float gravity = 100f;
    public float multi = 2f;

    private bool falling;


    

    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }
    
    private void Update(){
        grounded= col.Raycast(Vector2.down);
        jumpDelayCounter = grounded ? jumpDelay : (jumpDelayCounter -= Time.deltaTime);

        jumpBufferCounter = Input.GetButtonDown("Jump")? jumpBuffer:(jumpBufferCounter-=Time.deltaTime);

        HorizontalMovement();

        if (jumpDelayCounter>0f)
        {
            VerticalMovement();
        }
        

        ApplyGravity();
        
        
        
    }

    private void HorizontalMovement(){
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x,inputAxis*moveSpeed,moveSpeed*Time.deltaTime*10);
        

        if (col.Raycast(Vector2.right * velocity.x))//checks for object in dir of velocity
        {
            velocity.x = Mathf.MoveTowards(velocity.x,0, moveSpeed * Time.deltaTime * 10);
        }
    }

    private void VerticalMovement()
    {
        jumping = velocity.y > 0f;

        if (jumpDelayCounter>0f && jumpBufferCounter>0f)
        {
            if (col.Raycast(Vector2.up))//checks for something above player
            {
                velocity.y = 0f;
            }
            else
            {
                velocity.y = jumpForce;
                jumping = true;
                jumpBufferCounter = 0f;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpDelayCounter = 0f;
        }
        
        
        

        
    }

    private void ApplyGravity()
    {
        //if velocity is negative OR if the jump button isnt being held, second part is to make jump last logner if held
        velocity.y = grounded? Mathf.Max(velocity.y, 0f) : Mathf.Max(velocity.y, -40f); //stops gravity from being built up
        falling = velocity.y < 0f || !Input.GetButton("Jump");

        float multiplier = falling ? multi : 1f;

        velocity.y -= gravity* Time.deltaTime * multiplier;
        

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
