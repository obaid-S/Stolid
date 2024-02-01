using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Movement movement;

    public Sprite idle;
    public Sprite jump;
    public Sprite turn;
    public Animated run;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void LateUpdate()
    {
        run.enabled = movement.running;

        if (movement.jumping) {//pririoty
            spriteRenderer.sprite= jump;
        }else if (movement.turning)
        { 
            spriteRenderer.sprite= turn;
        }
        else if (!movement.running)
        {
            spriteRenderer.sprite= idle;
        }
    }
}
