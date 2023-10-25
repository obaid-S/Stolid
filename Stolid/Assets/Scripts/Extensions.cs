using UnityEngine;

public static class Extensions
{
    private static LayerMask Ground = LayerMask.GetMask("Ground");

    public static bool Raycast(this BoxCollider2D col, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, direction, 0.1f, Ground);

        return hit.collider != null;//if hit something return true
    }

    public static bool DotTest(this Transform transform, Transform other, Vector2 testdirection)
    {
        Vector2 direction = other.position-transform.position;
        return Vector2.Dot(direction.normalized, testdirection) > 0.3f;

    }
}
