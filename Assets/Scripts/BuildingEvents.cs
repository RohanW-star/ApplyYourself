using System.Collections;
using UnityEngine;

public class BuildingEvents : MonoBehaviour
{
    public Canvas canvas;

    public void SpawnCanvas()
    {
        Instantiate(canvas, canvas.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
