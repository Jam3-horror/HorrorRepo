using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public bool isLocked;
    public bool canBeOpened;
    public float openRadius;
    public GameObject fText;
    public AudioClip[] openSounds;

    Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, openRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                if (canBeOpened)
                {
                    fText.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.F) && !isLocked && canBeOpened)
                {
                    fText.SetActive(false);

                    animator.SetTrigger("Open");

                    AudioSource audio = GetComponent<AudioSource>();
                    audio.clip = openSounds[Random.Range(0, openSounds.Length)];
                    audio.Play();

                    canBeOpened = false;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, openRadius);
    }
}