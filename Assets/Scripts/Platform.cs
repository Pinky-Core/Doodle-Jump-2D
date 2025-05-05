using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.relativeVelocity.y <= 0)
            {
                collision.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
            }
        }
    }
}
