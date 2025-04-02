using UnityEngine;

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
