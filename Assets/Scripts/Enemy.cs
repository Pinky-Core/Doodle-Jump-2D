using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float moveRange = 2f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private bool movingRight = true;

    public float destroyHeight = -10f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Movimiento del enemigo de izquierda a derecha
        float move = moveSpeed * Time.deltaTime * (movingRight ? 1 : -1);
        transform.Translate(move, 0, 0);

        // Cambiar dirección si el enemigo ha llegado al límite de movimiento
        if (Mathf.Abs(transform.position.x - startPosition.x) > moveRange)
        {
            movingRight = !movingRight;
        }

        // Cambiar la orientación del sprite dependiendo de la dirección
        if (movingRight)
        {
            transform.localScale = new Vector3(0.31057f, 0.31057f, 0.31057f);  // Mirando a la derecha
        }
        else
        {
            transform.localScale = new Vector3(-0.31057f, 0.31057f, 0.31057f); // Mirando a la izquierda
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con el jugador, se carga la pantalla de GameOver
        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }

        // Si colisiona con un proyectil, destruir al enemigo
        else if (collision.collider.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
