using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoresManager : MonoBehaviour
{
    public static ScoresManager Instance;

    public int scoreA;
    public int scoreB;
    public int scoreC;

    public Slider sliderA;
    public Slider sliderB;
    public Slider sliderC;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeScores(int changeA, int changeB, int changeC)
    {
        scoreA += changeA;
        scoreB += changeB;
        scoreC += changeC;

        Debug.Log("A: " + scoreA + " B: " + scoreB + "C " + scoreC);
    }

    private void Update()
    {
        sliderA.value = scoreA;
        sliderB.value = scoreB;
        sliderC.value = scoreC;
    }
}
