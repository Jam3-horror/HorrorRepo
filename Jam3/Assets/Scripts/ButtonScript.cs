using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject wallToDeactivate;
    public GameObject monsterTriggerToActivate;
    public float activationRadius;
    public bool beenActivated;
    public GameObject fText;

    Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, activationRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player") && !beenActivated)
            {
                if (!beenActivated)
                {
                    fText.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    fText.SetActive(false);

                    animator.SetTrigger("Press");

                    wallToDeactivate.SetActive(false);
                    monsterTriggerToActivate.SetActive(true);

                    beenActivated = true;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, activationRadius);
    }
}
