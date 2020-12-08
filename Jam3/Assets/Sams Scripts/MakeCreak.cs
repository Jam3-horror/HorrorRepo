using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCreak : MonoBehaviour
{
    public AudioClip[] creaks;

    private int number;
    public AudioSource creakSource;

    void Start()
    {
        creakSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        number = Random.Range(0, creaks.Length);

        creakSource.clip = creaks[number];
        creakSource.Play();
    }
}
