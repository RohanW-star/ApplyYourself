using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform camera;

    void Start()
    {
        camera = Camera.main.transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.position);
        transform.rotation = camera.rotation;
    }
}
