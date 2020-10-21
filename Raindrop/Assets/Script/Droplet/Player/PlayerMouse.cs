using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : DropletBase
{
    [SerializeField] Vector3 mousePos;

    [SerializeField] float lerpSmoothing = 0.125f;
    [SerializeField] float turnSmoothing = 0.2f;

    protected override void RunUpdate()
    {
        Debug.Log(direction);
        AddInput();
        RotateSprite(direction.x);
        base.RunUpdate();
    }

    void AddInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        direction = (mousePos - transform.position);
        direction.z = 0;

        Mathf.Clamp(direction.x, -5.0f, 5.0f);
        Mathf.Clamp(direction.y, -5.0f, 5.0f);
    }

    void RotateSprite(float dir)
    {
        Quaternion desiredRotation = Quaternion.identity;
        if (dir != 0)//input accounts for deadzone
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

}
