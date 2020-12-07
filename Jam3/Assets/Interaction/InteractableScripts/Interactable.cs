using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactionRadius = 3f;
    public Transform interactableTransform;

    bool interacted = false;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        if (interactableTransform == null)
        {
            interactableTransform = transform;
        }
    }

    public virtual void Interact()
    {
        Debug.Log("This should be overwritten");
    }

    // Update is called once per frame
    void Update()
    {
        if(!interacted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= interactionRadius)
            {
                Interact();
                interacted = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
