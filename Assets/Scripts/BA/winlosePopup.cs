using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLosePopup : MonoBehaviour 
{
    public Button restartButton; // Button to restart the game
    public Button exitButton; // Button to exit the game

    void Start() 
    {
        // Assign button listeners to their respective functions
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);

        // Ensure the popup starts hidden
        gameObject.SetActive(false);
    }

    // Function to open the popup
    public void Open() 
    {
        gameObject.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    // Function to close the popup (if needed)
    public void Close() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    // Function to restart the game
    public void RestartGame() 
    {
        Time.timeScale = 1; // Resume before restarting
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Function to exit the game
    public void ExitGame() 
    {
        Application.Quit();
    }
}
