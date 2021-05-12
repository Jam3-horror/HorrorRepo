using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnDownRecordPlayer : MonoBehaviour
{
    public float activationRadius;
    public GameObject fText;

    float originalVolume;
    bool off;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        originalVolume = audioSource.volume;
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, activationRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    if(off)
                    {
                        audioSource.volume = 0;
                    }

                    if(!off)
                    {
                        audioSource.volume = originalVolume;
                    }

                    off = !off;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            fText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fText.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, activationRadius);
    }
}
