using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DropletBase
{
    /*
    [SerializeField] float turnSmoothing = 0.125f;
 
    protected override void RunUpdate()
    {
        AddInput();
        RotateSprite(direction.x);
        base.RunUpdate();
    }

    void AddInput()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
    }

    void RotateSprite(float dir)
    {
        Quaternion desiredRotation = Quaternion.identity;
        if(dir != 0)//input accounts for deadzone
        {
            desiredRotation.z = Mathf.Deg2Rad * 15 * dir;
        }
        else
        {
            desiredRotation.z = 0;
        }

        Quaternion smoothedRotation = Quaternion.Lerp(spriteHolder.transform.rotation, desiredRotation, turnSmoothing * Time.deltaTime);
        spriteHolder.transform.rotation = smoothedRotation;
    }


    protected override void OnAbsorbed()
    {
        Debug.Log("Player is Dead.");
    }
    */
}

