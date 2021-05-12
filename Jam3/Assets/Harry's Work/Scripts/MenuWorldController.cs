using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWorldController : MonoBehaviour
{
    [Header("World Setup")]
    public GameObject ghost;
    public GameObject[] spawns;
    public float spawnTestInterval;
    public int spawnChance;

    private void Start() 
    {
        InvokeRepeating("SpawnGhost",0, spawnTestInterval);
    }

    void SpawnGhost()
    {
        if(Random.Range(0, 100) <= spawnChance)
        {
            int spawnSelect = Random.Range(0, spawns.Length);

            Instantiate(ghost, spawns[spawnSelect].transform.position, Quaternion.identity);
        }
    }   
}
