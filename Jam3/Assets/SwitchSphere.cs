using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSphere : MonoBehaviour
{
    public Material goldMaterial;
    public Material originalMaterial;
    public Light thisLight;
    public Color goldColour;
    public Color originalColour;
    public bool isGold;
    public float activationRadius;
    public GameObject fText;

    private void Start()
    {
        originalMaterial = this.GetComponent<MeshRenderer>().material;
        originalColour = thisLight.color;
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
                    isGold = !isGold;
                    this.GetComponent<AudioSource>().Play();

                    if(isGold)
                    {
                        this.GetComponent<MeshRenderer>().material = goldMaterial;
                        thisLight.color = goldColour;
                    }

                    if(!isGold)
                    {
                        this.GetComponent<MeshRenderer>().material = originalMaterial;
                        thisLight.color = originalColour;
                    }
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
