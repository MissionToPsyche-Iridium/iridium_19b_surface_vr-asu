using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRFadeController : MonoBehaviour
{
    public Animator fadeAnimator;
    public CanvasGroup fadeGroup;
    public float delayBeforeFade = 20f;
    public float fadeDuration = 1f;

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

        int nextIndex = (currentSceneIndex + 1) % sceneCycle.Length;
        SceneManager.LoadScene(sceneCycle[nextIndex]); //loads new scene
    }
}

