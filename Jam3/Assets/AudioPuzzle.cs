using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPuzzle : MonoBehaviour
{
    public GameObject playSequence;
    public List<GameObject> sequence = new List<GameObject>();

    public GameObject[] spheres;

    public GameObject doorToOpen;
    public GameObject lightToChange;
    public Color lightColourChange;
    public Material materialChange;

    AudioClip[] sequenceArray;

    bool hasCompleted;

    private void Start()
    {
        sequenceArray = playSequence.GetComponent<PlaySequence>().clips;
    }

    private void Update()
    {
        if (sequence.Count == 0)
        {
            for (int i = 0; i < spheres.Length; i++)
            {
                spheres[i].SetActive(false);
            }
        }

        if (sequence.Count == 1)
        {
            spheres[0].SetActive(true);
        }

        if (sequence.Count == 2)
        {
            spheres[1].SetActive(true);
        }

        if (sequence.Count == 3)
        {
            spheres[2].SetActive(true);

            if (sequenceArray[0] == sequence[0].GetComponent<AudioSource>().clip &&
                sequenceArray[1] == sequence[1].GetComponent<AudioSource>().clip &&
                sequenceArray[2] == sequence[2].GetComponent<AudioSource>().clip)
            {
                if(!hasCompleted)
                {
                    Open();
                    doorToOpen.GetComponent<OpenDoor>().PlayAudio();
                    hasCompleted = true;
                    sequence.Clear();
                }
            }

            else
            {
                sequence.Clear();
            }
        }

        if (sequence.Count > 3)
        {
            sequence.Clear();
        }
    }

    void Open()
    {
        doorToOpen.GetComponent<OpenDoor>().isLocked = false;
        doorToOpen.GetComponent<MeshRenderer>().material = materialChange;
        lightToChange.GetComponent<Light>().color = lightColourChange;
    }
}
