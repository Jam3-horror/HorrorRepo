using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepAudio : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    bool walking;

    Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        InvokeRepeating("PlayFootstepsAudio", 0, 0.4f);
    }

    private void Update()
    {
        if(rb.velocity != Vector3.zero)
        {
            walking = true;
        }

        if(rb.velocity == Vector3.zero)
        {
            walking = false;
        }
    }

    void PlayFootstepsAudio()
    {
        if (walking)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audio.Play();
        }
    }
}
