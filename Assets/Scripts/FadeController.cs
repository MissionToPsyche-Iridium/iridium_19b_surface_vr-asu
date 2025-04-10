using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VRFadeController : MonoBehaviour
{
    public Animator fadeAnimator;
    public CanvasGroup fadeGroup;
    public float delayBeforeFade = 20f;
    public float fadeDuration = 1f;
    public GameObject playAgainButton; // PlayAgainButton2 in MainScene

    private string[] sceneCycle = { "MainScene", "LaunchScene", "TestCraft" };
    private int currentSceneIndex;

    void Start()
    {
        fadeGroup.alpha = 0f;
        fadeAnimator.ResetTrigger("FadeNow"); // resets fadenow from prev build

        currentSceneIndex = GetCurrentSceneIndex();
        StartCoroutine(FadeAfterDelay());
    }

    int GetCurrentSceneIndex()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        for (int i = 0; i < sceneCycle.Length; i++)
        {
            if (sceneCycle[i] == currentScene)
                return i;
        }
        return 0; // default to first scene if not found
    }

    IEnumerator FadeAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFade); //waits 20sec to fade
        fadeAnimator.SetTrigger("FadeNow"); // "FadeNow in animator pane
        yield return new WaitForSeconds(fadeDuration);

                if (currentSceneIndex < sceneCycle.Length - 1)
        {
            // Move to next scene
            int nextIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(sceneCycle[nextIndex]);
        }
        else
        {
            // Final scene reached – show Play Again button
            if (playAgainButton != null)
            {
                playAgainButton.SetActive(true);
            }
            Debug.Log("All scenes played");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneCycle[0]);
    }
}

