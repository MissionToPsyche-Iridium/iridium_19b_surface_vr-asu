using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isPaused = false; // makes sure the resume screen isnt loaded
    public GameObject pauseScreen; // "Pause Screen" in MainScene
    public GameObject resumeButton; // "Resume Button" in MainScene
    public GameObject pauseButton; // "Pause Button in MainScene

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

    private void Start()
    {
        UpdateUI(false);
    }


    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;  // Freeze the game
        UpdateUI(true);
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;  // Resume the game
        UpdateUI(false);
        Debug.Log("Game Resumed");
    }

    public void RestartGame()
    {
        Time.timeScale = 1; 
        Destroy(gameObject); // deletes the GameManager obj
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // rebuilds MainScene
        Debug.Log("Restarting Game"); 
    }

    private void UpdateUI(bool isPaused)
    {
        pauseScreen?.SetActive(isPaused);  // show/hide pause screen
        resumeButton?.SetActive(isPaused); // show Resume button only when paused
        pauseButton?.SetActive(!isPaused); // show Pause button only when NOT paused
    }
}
