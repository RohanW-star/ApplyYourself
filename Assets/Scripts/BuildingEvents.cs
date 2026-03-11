using UnityEngine;

public class BuildingEvents : MonoBehaviour
{
    public GameObject changedBuilding;
    public GameObject[] extraChanges;
    public Canvas canvas;
    
    public void SpawnCanvas()
    {
        Instantiate(canvas, canvas.transform.position, Quaternion.identity);
    }
}
