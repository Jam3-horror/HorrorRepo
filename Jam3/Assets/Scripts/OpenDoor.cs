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

                    canBeOpened = false;

                    animator.SetTrigger("Open");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, openRadius);
    }
}