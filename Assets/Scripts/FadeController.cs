using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRFadeController : MonoBehaviour
{
    public Animator fadeAnimator;
    public CanvasGroup fadeGroup;
    public string nextScene;
    public float delayBeforeFade = 20f;
    public float fadeDuration = 1f;

    void Start()
    {
        fadeGroup.alpha = 0f;
        fadeAnimator.ResetTrigger("FadeNow"); // resets fadenow from prev build
        StartCoroutine(FadeAfterDelay());
    }

    IEnumerator FadeAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFade); //waits 20sec to fade
        fadeAnimator.SetTrigger("FadeNow"); // "FadeNow in animator pane
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(nextScene); //loads new scene
    }
}
