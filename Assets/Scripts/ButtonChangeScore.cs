using UnityEngine;

public class ButtonChangeScore : MonoBehaviour
{
    public int changeA;
    public int changeB;
    public int changeC;
    public GameObject changedBuilding;
    public GameObject[] extraChanges;

    public void ApplyEffect()
    {
        ScoresManager.Instance.ChangeScores(changeA, changeB, changeC);
        EventManager.Instance.EventDeactivated();
        Destroy(transform.root.gameObject);
    }
}
