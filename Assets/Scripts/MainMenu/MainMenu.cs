using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to start the game by loading the game scene
    public void Play()
    {
        SceneManager.LoadScene("1. Game");
    }

    // Method to quit the application
    public void Quit()
    {
        // Check if the application is running in the editor
#if UNITY_EDITOR
        // If running in the editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running on a build, close the application
        Application.Quit();
#endif
    }
}
