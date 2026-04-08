using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoresManager : MonoBehaviour
{
    public static ScoresManager Instance;

    public GameObject[] stars;
    public GameObject[] items;
    public GameObject[] items2;

    public GameObject bio1;
    public GameObject bio2;
    public GameObject bio3;
    public GameObject dirty;
    public GameObject dirty2;

    public GameObject peep1;
    public GameObject peep2;
    public GameObject peep3;

    public GameObject ener1;
    public GameObject ener2;
    public GameObject ener3;

    private int currentStarIndex = 0;
    private int currentItemIndex = 0;
    private int currentItemIndex2 = 0;

    void Awake()
    {
        Instance = this;
    }

    public enum ElementType
    {
        Biodiversity,
        People,
        Energie
    }

    public void AddToElement(ElementType element, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            switch (element)
            {
                case ElementType.Biodiversity:
                    if (currentStarIndex < stars.Length)
                    {
                        stars[currentStarIndex].SetActive(true);
                        currentStarIndex++;
                    }
                    break;

                case ElementType.People:
                    if (currentItemIndex < items.Length)
                    {
                        items[currentItemIndex].SetActive(true);
                        currentItemIndex++;
                    }
                    break;

                case ElementType.Energie:
                    if (currentItemIndex2 < items2.Length)
                    {
                        items2[currentItemIndex2].SetActive(true);
                        currentItemIndex2++;
                    }
                    break;
            }
        }
    }

    private void Update()
    {
        if (currentStarIndex == 1)
        {
            Instantiate(bio1);
            Destroy(dirty2);
        }
        if (currentStarIndex == 2)
        {
            Instantiate(bio2);
            Destroy(dirty);
        }
        if (currentStarIndex == 3)
        {
            Instantiate(bio3);
        }

        if (currentItemIndex == 1)
        {
            Instantiate(peep1);
        }
        if (currentItemIndex == 2)
        {
            Instantiate(peep2);
        }
        if (currentItemIndex == 3)
        {
            Instantiate(peep3);
        }

        if (currentItemIndex2 == 1)
        {
            Instantiate(ener1);
        }
        if (currentItemIndex2 == 2)
        {
            Instantiate(ener2);
        }
        if (currentItemIndex2 == 3)
        {
            Instantiate(ener3);
        }
    }
}
