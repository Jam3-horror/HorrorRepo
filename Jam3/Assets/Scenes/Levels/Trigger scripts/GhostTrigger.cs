using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    bool move_ghost = false;
    bool triggered = false;

    public GameObject GhostSphere;

    public Transform start_pos;

    public Transform end_pos;

    public float speed = 0.1f;


    private float startTime;

    private float journeyLength;

    void Start()
    {
        

        journeyLength = Vector3.Distance(start_pos.position, end_pos.position);
    }

    void Update()
    {
        if (move_ghost)
        {
            float distCovered = (Time.time - startTime) * speed;

            float fractionOfJourney = distCovered / journeyLength;

            GhostSphere.transform.position = Vector3.Lerp(start_pos.position, end_pos.position, fractionOfJourney);

            if (GhostSphere.transform.position == end_pos.position)
            {
                Destroy(GhostSphere);
                move_ghost = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !triggered)
        {
            startTime = Time.time;
            move_ghost = true;
            triggered = true;
        }
    }

}
