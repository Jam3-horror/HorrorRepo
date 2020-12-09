using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMonster : MonoBehaviour
{
    public AudioClip[] footstepSounds;

    public float speed;
    public bool running;

    Animator mainCamAnimator;

    private void Start()
    {
        mainCamAnimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

        StartCoroutine("Run");

        InvokeRepeating("PlayFootstepsAudio", 0, 0.3f);
    }

    private void Update()
    {
        if(running)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    void PlayFootstepsAudio()
    {
        if(running)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audio.pitch = 0.5f;
            audio.Play();
        }
    }

    IEnumerator Run()
    {
        mainCamAnimator.SetBool("Shaking", true);

        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);

        mainCamAnimator.SetBool("Shaking", false);

        running = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().MonsterKill();
        }
    }
}
