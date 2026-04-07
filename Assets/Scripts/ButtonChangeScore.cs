using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeScore : MonoBehaviour
{
    public int changeA;
    public int changeB;
    public int changeC;

    public GameObject explanation;

    public string oldName;
    public GameObject[] extraChanges;
    private ClickOnBuildings ClickOnBuildings;

    public void ApplyEffect()
    {
        ScoresManager.Instance.ChangeScores(changeA, changeB, changeC);
        EventManager.Instance.EventDeactivated();

        GameObject obj = GameObject.Find(oldName);

        if (obj != null)
        {
            Destroy(obj);
        }

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
        Destroy(transform.root.gameObject);
    }
}
