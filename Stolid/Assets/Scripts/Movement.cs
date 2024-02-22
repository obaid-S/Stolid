
using System;
using Unity.Mathematics;
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
    public bool running => Mathf.Abs(velocity.x) > 0.5f || Mathf.Abs(inputAxis)>0.5f;
    public bool turning => (inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f);


    //delay accepted b4 jump input
    public float jumpDelay = 1f;
    private float jumpDelayCounter =10f;

    //delay accepted b4 jump buffer
    public float jumpBuffer = 1f;
    private float jumpBufferCounter = 0f;

    public float gravity = 100f;
    public float multi = 2f;

    private bool falling;

    private Animator playerAnimation;
    public float timeSinceLastX;

    public float leftSide;
    public bool allowMove;

    public float timeControlSpeed;
    public float timeIncreaseSpeed;
    public float timeResetSpeed;





    

    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        playerAnimation= GetComponent<Animator>();
    }
    
    private void Update(){
        grounded= col.Raycast(Vector2.down);
        jumpDelayCounter = grounded ? jumpDelay : (jumpDelayCounter -= Time.deltaTime);

        jumpBufferCounter = Input.GetButtonDown("Jump")? jumpBuffer:(jumpBufferCounter-=Time.deltaTime);
        timeControlSpeed=Input.GetButton("timeSpeed")?timeControlSpeed:Mathf.MoveTowards(timeControlSpeed,0,Time.deltaTime*timeResetSpeed);
        timeSinceLastX = Input.GetButton("Horizontal") ? 0 : ((timeSinceLastX>=5)?5:(timeSinceLastX+=Time.deltaTime));//time before idle animation plays

        if (allowMove){
            HorizontalMovement();
            timeControl();

            if (jumpDelayCounter>0f)
            {
                VerticalMovement();
            }
            //animations
            
        }else{
            velocity.x=0f;
        }

        playerAnimation.SetBool("grounded", grounded);
        playerAnimation.SetFloat("ySpeed",velocity.y);
        playerAnimation.SetFloat("speed", Mathf.Abs(velocity.x));
        playerAnimation.SetFloat("sinceLastAcceleration", timeSinceLastX);
       

        

        
        ApplyGravity();
    }

    private void HorizontalMovement(){
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x,inputAxis*moveSpeed,moveSpeed*Time.deltaTime*10);
        
        if (velocity.x < 0)// changes char direction to velocity dir
        {
            transform.eulerAngles = new Vector3(0,180);
        }
        else if(velocity.x>0)
        {
            transform.eulerAngles = new Vector3(0,0);

        }
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

        position.x = (float)Math.Clamp(position.x, leftSide, 14.5);
        

        rigidbody.MovePosition(position);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))//ground collision
        {
            if (col.Raycast(Vector2.up))
            {
                velocity.y = 0f;
            }
            
        }
    }
    private void timeControl(){

        if(Input.GetButton("timeSpeed"))
        {
            timeControlSpeed+=Time.deltaTime*timeIncreaseSpeed*MathF.Sign(Input.GetAxis("timeSpeed"));
        }
        timeControlSpeed= Mathf.Clamp(timeControlSpeed,-1,1);
    }
}
