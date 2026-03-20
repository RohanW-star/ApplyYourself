using UnityEngine;

public class LookAtCenter : MonoBehaviour
{
    public Transform centre;

    void Update()
    {
        transform.LookAt(centre.position);
    }
}
