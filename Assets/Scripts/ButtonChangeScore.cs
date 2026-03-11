using UnityEngine;

public class ButtonChangeScore : MonoBehaviour
{
    public int changeA;
    public int changeB;
    public int changeC;

    public void ApplyEffect()
    {
        ScoresManager.Instance.ChangeScores(changeA, changeB, changeC);
        Destroy(transform.root.gameObject);
    }
}
