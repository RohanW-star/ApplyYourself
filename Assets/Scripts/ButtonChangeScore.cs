using UnityEngine;

public class ButtonChangeScore : MonoBehaviour
{
    public int changeA;
    public int changeB;
    public int changeC;
    public GameObject changedBuilding;
    public GameObject oldBuilding;
    public GameObject[] extraChanges;

    public void ApplyEffect()
    {
        ScoresManager.Instance.ChangeScores(changeA, changeB, changeC);
        EventManager.Instance.EventDeactivated();

        Destroy(oldBuilding);
        Instantiate(changedBuilding);

        foreach (var change in extraChanges)
        {
            change.SetActive(true);
        }

        Destroy(transform.root.gameObject);
    }
}
