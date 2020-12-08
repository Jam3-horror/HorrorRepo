using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWood : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;

    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            GetComponent<ParticleSystem>().Play();

            source.clip = clip;
            source.Play();

            hasPlayed = false;
        }
    }
}
