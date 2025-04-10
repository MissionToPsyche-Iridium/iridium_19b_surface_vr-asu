using UnityEngine;

public class LaunchRocketBehavior : MonoBehaviour
{
    private float _waitTime = 0.0f;
    private bool _inLaunch = false;

    private float _acceleration = 0.0f;
    private float _velocity = 0.0f;

    void Start()
    {
        RenderSettings.skybox.SetFloat("_Blend", 0.0f);
    }

    void Update()
    {
        if (_inLaunch) {
            _velocity += _acceleration * Time.deltaTime;
            transform.position += new Vector3(0, _velocity * Time.deltaTime, 0);
            var blend = Mathf.Min(transform.position.y / 40.0f, 1.0f);
            RenderSettings.skybox.SetFloat("_Blend", blend);
        } else {
            _waitTime += Time.deltaTime;
        }

        if (!_inLaunch && _waitTime > 16.0f) {
            _inLaunch = true;
            _acceleration = 5.0f;
        }
    }
}
