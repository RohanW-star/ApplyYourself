using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnBuildings : MonoBehaviour
{
    private BuildingEvents buildingEvents;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            bool hitSomething = Physics.Raycast(ray, out hit);
            if (hitSomething)
            {
                var selection = hit.transform;
                if (selection.CompareTag("CanClick"))
                {
                    Debug.Log("Start event");
                    buildingEvents = hit.transform.GetComponent<BuildingEvents>();
                    buildingEvents.SpawnCanvas();
                }
            }
        }
    }
}
