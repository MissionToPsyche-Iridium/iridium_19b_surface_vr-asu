using UnityEngine;

// Makes the XR sim persist across scenes (only necesarry for desktop dev)
public class MakePersistent : MonoBehaviour
{
    private static bool isInitialized = false;

    void Awake()
    {
        if (!isInitialized)
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("MakePersistent set up: " + gameObject.name);
            isInitialized = true;
        }
        else
        {
            Debug.Log("Duplicate detected and destroyed: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
