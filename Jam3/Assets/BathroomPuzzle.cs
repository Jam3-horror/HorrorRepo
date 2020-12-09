using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomPuzzle : MonoBehaviour
{
    public GameObject[] spheres;
    public GameObject doorToOpen;
    public GameObject lightToChange;
    public Color lightColourChange;
    public Material materialChange;
    bool hasPlayed;

    private void Update()
    {
        if(spheres[0].GetComponent<SwitchSphere>().isGold &&
           spheres[1].GetComponent<SwitchSphere>().isGold &&
           spheres[2].GetComponent<SwitchSphere>().isGold &&
           spheres[3].GetComponent<SwitchSphere>().isGold == false)
        {
            doorToOpen.GetComponent<OpenDoor>().isLocked = false;
            doorToOpen.GetComponent<MeshRenderer>().material = materialChange;
            lightToChange.GetComponent<Light>().color = lightColourChange;

            if (!hasPlayed)
            {
                doorToOpen.GetComponent<OpenDoor>().PlayAudio();
                hasPlayed = true;
            }            
        }
    }
}
