using UnityEngine;

public class PlanetaryRotation : MonoBehaviour
{
    [SerializeField] Vector3 axialTilt;
    [SerializeField] float _period; //time taken for 1 rotation


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(axialTilt);
    }

    // Update is called once per frame
    void Update()
    {
        //set axial tilt
        CelestialRotation();
    }

    void CelestialRotation()
    {
        float radius = GetComponent<SphereCollider>().radius; //will change. Not Robust enough

        float rotation = (2 * Mathf.PI * radius) / _period;
        Vector3 rotate = new Vector3(0, rotation, 0);
        transform.Rotate(rotate * Time.deltaTime, Space.Self);
    }
}
