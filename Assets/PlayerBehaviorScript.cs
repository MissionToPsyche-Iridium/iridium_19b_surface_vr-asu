using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer _videoPlayer;
    private UnityEngine.GameObject _screen;
    private UnityEngine.GameObject _progress;
    private UnityEngine.GameObject _rocket;

    private bool _inLaunch = false;

    void Start()
    {
        _screen = transform.Find("Screen").gameObject;
        _progress = transform.Find("Progress").gameObject;

        _rocket = GameObject.FindGameObjectWithTag("Player");

        _videoPlayer = _screen.GetComponent<UnityEngine.Video.VideoPlayer>();
        _videoPlayer.loopPointReached += EndReached;
    }

    void Update()
    {
        if (_inLaunch) {
            var step = Time.deltaTime;
            var targetPosition = new Vector3(0.0f, 100.0f, -10.0f);
            _rocket.transform.position = Vector3.MoveTowards(_rocket.transform.position, targetPosition, step);
        } else {
            var progress = _videoPlayer.time / _videoPlayer.length;
            // calculate midpoint between -17.77/2 = -8.88 -> 0

            _progress.transform.localScale = new Vector3((float)(progress * 17.77), 1.0f, 0.5f);
            _progress.transform.localPosition = new Vector3((float)(-8.888 + progress * 8.888), 6, 0);
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        _progress.SetActive(false);
        _inLaunch = true;
    }
}
