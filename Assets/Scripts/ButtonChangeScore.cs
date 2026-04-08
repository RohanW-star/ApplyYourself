using System.Collections.Generic;
using UnityEngine;
using static ScoresManager;

public class ButtonChangeScore : MonoBehaviour
{
    public GameObject explanation;

    public int bioIncrease;
    public int peopleIncrease;
    public int energieIncrease;

    public string[] oldName;
    public GameObject[] extraChanges;
    private ClickOnBuildings ClickOnBuildings;

    private GameObject obj;

    public void ApplyEffect()
    {
        EventManager.Instance.EventDeactivated();

        foreach (var name in oldName)
        {
            obj = GameObject.Find(name);

            if (obj != null)
            {
                Destroy(obj);
            }
        }

        if (obj != null)
        {
            Destroy(obj);
        }

        ScoresManager.Instance.AddToElement(ElementType.Biodiversity, bioIncrease);
        ScoresManager.Instance.AddToElement(ElementType.People, peopleIncrease);
        ScoresManager.Instance.AddToElement(ElementType.Energie, energieIncrease);

        foreach (var change in extraChanges)
        {
            Instantiate(change, change.transform.position,change.transform.rotation);
        }
        
        Instantiate(explanation);
        Destroy(transform.root.gameObject);
    }

    public void End()
    {
        ClickOnBuildings = Object.FindFirstObjectByType<ClickOnBuildings>();
        ClickOnBuildings.enabled = true;
        ScoresManager.Instance.canEnd = true;
        Destroy(transform.root.gameObject);
    }
}
