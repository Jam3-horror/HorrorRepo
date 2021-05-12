using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [Header("Ghost Setup")]
    public float minSpeed;
    public float maxSpeed;
    float speed;
    Vector3 moveVector;

    private void Start() 
    {
        speed = Random.Range(minSpeed, maxSpeed);

         if(transform.position.x >= 0)
         {
             moveVector = Vector3.left;
         }

         if(transform.position.x <= 0)
         {
             moveVector = Vector3.right;
         }
    }

    private void Update() 
    {
        transform.Translate(moveVector * speed * Time.deltaTime);
    }
}
