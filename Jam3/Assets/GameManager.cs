using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATES
{
    windowopened, test2, test3
}

public class Event
{
    public STATES state;
    public bool has_triggered = false;
}

public class GameManager : MonoBehaviour
{
    List<Event> events = new List<Event>();
    public int event_count = 3;

    void Start()
    {
        for (int i = 0; i < event_count; i++)
        {
            Event e = new Event();
            e.state = (STATES)i;
            events.Add(e);
        }
    }

    void QueryState(STATES state, GameObject go)
    {
        int id = (int)state;

        if (id != 0)
        {
            if (!events[id].has_triggered && events[id - 1].has_triggered)
            {
                DoState(events[id], null);
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            if (!events[id].has_triggered)
            {
                DoState(events[id], null);
            }
        }
    }

    void DoState(Event e, GameObject go)
    {
        e.has_triggered = true;

        switch (e.state)
        {
            case STATES.windowopened:
                {
                    Debug.Log("1");
                    break;
                }

            case STATES.test2:
                {
                    Debug.Log("2");
                    break;
                }

            case STATES.test3:
                {
                    Debug.Log("3");
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            QueryState(STATES.windowopened, null);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            QueryState(STATES.test2, null);
        }
    }
}
