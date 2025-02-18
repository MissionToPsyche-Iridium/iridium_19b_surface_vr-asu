using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isPaused = false; // makes sure the resume screen isnt loaded
    public GameObject pauseScreen; // "Pause Screen" in MainScene

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;  // Freeze or resume game

        if (pauseScreen != null) {
            pauseScreen.SetActive(isPaused);  // Show or hide pause menu
        }
        Debug.Log("Pausing Game");
    }

    public void RestartGame()
    {
        Time.timeScale = 1; 
        Destroy(gameObject); // deletes the GameManager obj
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // rebuilds MainScene
        Debug.Log("Restarting Game"); 
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; 
        pauseScreen.SetActive(false);
        Debug.Log("Resuming Game"); 

    }
}
