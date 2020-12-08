using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Interactable
{
    public Item item;
    public bool IsObsered = false;
    public GameObject ObsPoint;
    private Transform pFoward;
    Vector3 ForwardP;
    float horiO;
    float vertiO;
    Vector3 DesRot;
    Vector3 leftRot;
    public GameObject Player;
    private Rigidbody rb;
    Vector3 startPos;
    Quaternion startRot;
    bool PickUped = true;

   public void Start()
    {
        pFoward = player.transform;
        startPos = transform.position;
        startRot = transform.rotation;

        rb = GetComponent<Rigidbody>();
        
    }
  
    public override void Interact()
    {
      
        horiO = Input.GetAxis("Mouse X");
        vertiO = Input.GetAxis("Mouse Y");
        ForwardP = pFoward.up;
        leftRot = pFoward.right;
        DesRot = (ForwardP * horiO + leftRot * vertiO);

        if(Input.GetKeyUp(KeyCode.E))
        {
            PickUped = false;
        }
                
        IsObsered = true;

        if(IsObsered)
        {
            Observe();
        }
        if(IsObsered && Input.GetKeyDown(KeyCode.E) && PickUped == false)
        {       
            Pickup();
        }
        if(IsObsered && Input.GetKeyDown(KeyCode.R))
        {
            PutDown();
        }
    }

    void Pickup()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        bool successfulPickup = Inventory.instance.Add(item);
        if (successfulPickup)
        {
            Destroy(gameObject);
        }
    }
    void Observe()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        rb.useGravity = false;
        transform.position = Vector3.Lerp(transform.position, ObsPoint.transform.position, 10 * Time.deltaTime);
        transform.Rotate(DesRot, Space.World);
    }
    void PutDown()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        StopInteraction();
        rb.useGravity = true;
        transform.position = Vector3.Lerp(transform.position, startPos, 10 * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, startRot, 0.1f);        
    }   
}
