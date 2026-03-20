using UnityEngine;
using System.Collections.Generic;

public class ClickPhone : MonoBehaviour
{
    [SerializeField] private Transform canvasParent;

    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    
    public void OnClick()
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        foreach (Transform child in children)
        {
            child.gameObject.SetActive(true);
            child.SetParent(canvasParent);

        }

        gameObject.SetActive(false);
    }
}
