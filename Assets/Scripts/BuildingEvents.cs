using System.Collections;
using UnityEngine;

public class BuildingEvents : MonoBehaviour
{
    public Canvas canvas;
    private ClickOnBuildings ClickOnBuildings;

    private void Start()
    {
        ClickOnBuildings = Object.FindFirstObjectByType<ClickOnBuildings>();
    }
    public void SpawnCanvas()
    {
        Instantiate(canvas, canvas.transform.position, Quaternion.identity);
        ClickOnBuildings.enabled = false;
        Destroy(this.gameObject);
    }
}
