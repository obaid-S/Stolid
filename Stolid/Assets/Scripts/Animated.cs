using UnityEngine;

public class Animated : MonoBehaviour
{
    public Sprite[] sprites;
    public float framerate = 1f / 12f;//change to change framerate

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Animate), framerate, framerate);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        frame++;
        if (frame >= sprites.Length) {
            frame = 0;
        }

        if (frame >= 0 && frame<sprites.Length) { 
        spriteRenderer.sprite = sprites[frame];
        }
    }
}
