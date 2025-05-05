using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 12f; 
    public float maxX = 8f;        
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
        float inputX = 0f;

        if (SystemInfo.supportsGyroscope)
        {
            inputX = -Input.gyro.rotationRateUnbiased.z;
        }

        Vector2 move = new Vector2(inputX * moveSpeed, rb.velocity.y);
        rb.velocity = move;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
        transform.position = pos;

        if (inputX > 0)
        {
            transform.localScale = new Vector3(0.4688848f, 0.472276f, 1);
        }
        else if (inputX < 0)
        {
            // Mover a la izquierda
            transform.localScale = new Vector3(-0.4688848f, 0.472276f, 1);
        }

    }
}
