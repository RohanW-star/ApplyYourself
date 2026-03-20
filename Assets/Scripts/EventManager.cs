using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public int activeEvents = 0;
    public int maxActiveEvents = 2;

    void Awake()
    {
        Instance = this;
    }

    public bool CanSpawn()
    {
        return activeEvents < maxActiveEvents;
    }

    public void EventActivated()
    {
        activeEvents++;
    }

    public void EventDeactivated()
    {
        activeEvents--;
    }
}
