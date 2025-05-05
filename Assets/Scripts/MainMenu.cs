using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para el manejo de los UI buttons

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        // Asignar las acciones de los botones
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Método para iniciar el juego
    void StartGame()
    {
        // Cargar la escena del juego (asegúrate de que esté añadida en Build Settings)
        SceneManager.LoadScene("Game"); // Asegúrate de que "GameScene" es el nombre de tu escena de juego.
    }

    // Método para salir del juego
    void ExitGame()
    {
        // Salir de la aplicación (funcionará solo en compilados, no en el editor)
        Application.Quit();
    }
}
