using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float fallThreshold = -10f; // Altura mínima antes de game over

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
