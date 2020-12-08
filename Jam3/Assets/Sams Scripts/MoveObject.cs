using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float AngleOffsetX = 0;
    public float AngleOffsetY = 0;
    public float AngleOffsetZ = 0;

    public float OffsetMoveX = 0;
    public float OffsetMoveY = 0;
    public float OffsetMoveZ = 0;

    public float Speed = 1f;

    private bool hasMoved = false;

    private Vector3 vec;
    private Vector3 vecRotate;

    private Vector3 startPos;
    private Vector3 startRot;

    //Grab start position and rotation to use in comparison to offsets when moving, set vectors for translations
    void Start()
    {
        startPos = transform.position;
        startRot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        vecRotate = new Vector3(AngleOffsetX, AngleOffsetY, AngleOffsetZ);
        vecRotate.Normalize();

        vec = new Vector3(OffsetMoveX, OffsetMoveY, OffsetMoveZ);
        vec.Normalize();
    }

    //check if the object has moved before, and if not start the transforms (as long as it has not reached its goal)
    void Update()
    {
        if (hasMoved && !checkRot())
        {
            transform.Rotate(vecRotate * Speed * Time.deltaTime);
        }
        if (hasMoved && !checkPos())
        {
            transform.Translate(vec * Speed * Time.deltaTime);
        }
    }

    //When player is in trigger box, set true to begin translations
    private void OnTriggerEnter(Collider other)
    {
        if (!hasMoved && 
            ((AngleOffsetX != 0 || AngleOffsetY != 0 || AngleOffsetZ != 0) ||
            OffsetMoveX != 0 || OffsetMoveY != 0 || OffsetMoveZ != 0))
        {
            hasMoved = true;
        }
    }

    //Check if object has reached original point plus offset
    private bool checkRot()
    {
        if (AngleOffsetX < 0 && transform.rotation.x * 100 > startRot.x + AngleOffsetX ||
            AngleOffsetX > 0 && transform.rotation.x * 100 < startRot.x + AngleOffsetX)
        {
            return false;
        }
        if (AngleOffsetY < 0 && transform.rotation.y * 100 > startRot.y + AngleOffsetY ||
            AngleOffsetY > 0 && transform.rotation.y * 100 < startRot.y + AngleOffsetY)
        {
            return false;
        }
        if (AngleOffsetZ < 0 && transform.rotation.z * 100 > startRot.z + AngleOffsetZ ||
            AngleOffsetZ > 0 && transform.rotation.z * 100 < startRot.z + AngleOffsetZ)
        {
            return false;
        }
        return true;
    }

    //Check if object has reached original point plus offset
    private bool checkPos()
    {
        if (OffsetMoveX < 0 && transform.position.x > startPos.x + OffsetMoveX ||
            OffsetMoveX > 0 && transform.position.x < startPos.x + OffsetMoveX)
        {
            return false;
        }
        if (OffsetMoveY < 0 && transform.position.y > startPos.y + OffsetMoveY ||
            OffsetMoveY > 0 && transform.position.y < startPos.y + OffsetMoveY)
        {
            return false;
        }
        if (OffsetMoveZ < 0 && transform.position.z > startPos.z + OffsetMoveZ ||
            OffsetMoveZ > 0 && transform.position.z < startPos.z + OffsetMoveZ)
        {
            return false;
        }

        return true;
    }
}
