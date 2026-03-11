using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEvents : MonoBehaviour
{
    [SerializeField] private float timer;

    private List<GameObject> events;

    void Start()
    {
        events = new List<GameObject>(GameObject.FindGameObjectsWithTag("CanClick"));

        foreach (GameObject obj in events)
        {
            obj.SetActive(false);
        }

        timer = 2f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SpawnEvent();
        }
    }

    private void SpawnEvent()
    {
        if (events.Count == 0) return;

        int randomIndex = Random.Range(0, events.Count);
        GameObject chosenEvent = events[randomIndex];

        chosenEvent.SetActive(true);
        events.RemoveAt(randomIndex);

        timer = Random.Range(7f, 15f);
    }
}
