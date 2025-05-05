using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Asegúrate de tener esto para usar los UI buttons

public class GameOverMenu : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;

    void Start()
    {
        // Botón de reiniciar
        restartButton.onClick.AddListener(RestartGame);

        // Botón de menú
        menuButton.onClick.AddListener(GoToMenu);
    }

    // Reiniciar el juego (volver a cargar la escena actual)
    void RestartGame()
    {
        // Recargar la escena activa (el juego)
        SceneManager.LoadScene("Game");
    }

    // Volver al menú principal
    void GoToMenu()
    {
        // Aquí asumes que tienes una escena llamada "MainMenu" o algo similar
        SceneManager.LoadScene("MainMenu");
    }
}
