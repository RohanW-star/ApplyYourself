using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEvents : MonoBehaviour
{
    [SerializeField] private float timer;

    [SerializeField] private List<GameObject> events;

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
        if (EventManager.Instance.CanSpawn())
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime * 0.1f;
        }

        if (timer <= 0)
        {
            SpawnEvent();
        }
    }

    private void SpawnEvent()
    {
        if (events.Count == 0) return;

        if (!EventManager.Instance.CanSpawn()) return;

        int randomIndex = Random.Range(0, events.Count);
        GameObject chosenEvent = events[randomIndex];

        chosenEvent.SetActive(true);
        EventManager.Instance.EventActivated();
        events.RemoveAt(randomIndex);

        timer = Random.Range(6f, 11f);
    }
}
