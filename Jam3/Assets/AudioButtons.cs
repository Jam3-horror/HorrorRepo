using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButtons : MonoBehaviour
{
    public float activationRadius;
    public GameObject fText;
    public AudioSource audioSource;
    public GameObject puzzleController;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, activationRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    audioSource.Play();
                    puzzleController.GetComponent<AudioPuzzle>().sequence.Add(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
