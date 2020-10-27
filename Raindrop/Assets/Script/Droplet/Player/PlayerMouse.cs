using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : PlayerHolder
{
    [SerializeField] Vector3 mousePos = Vector3.zero;

    [SerializeField] float turnSmoothing = 0.2f;

    [SerializeField] float minTurn = -1;
    [SerializeField] float maxTurn = 1;

    [SerializeField] float shrinkage = 0.1f;

    protected override void RunUpdate()
    {
        ShrinkOverTime();
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

    //Movement
    void RotateSprite(float dir)
    {
        Quaternion desiredRotation = Quaternion.identity;
        if (dir != 0)//input accounts for deadzone
        {
            desiredRotation.z = Mathf.Clamp(Mathf.Deg2Rad * 15 * dir, Mathf.Deg2Rad * minTurn, Mathf.Deg2Rad * maxTurn);
        }
        else
        {
            desiredRotation.z = 0;
        }

        Quaternion smoothedRotation = Quaternion.Lerp(spriteHolder.transform.rotation, desiredRotation, turnSmoothing * Time.deltaTime);
        spriteHolder.transform.rotation = smoothedRotation;
    }

    //Collision
    protected override void OnAbsorbed()
    {
    }

    void ShrinkOverTime()
    {
        spriteHolder.transform.localScale -= Vector3.one * shrinkage * Time.deltaTime;
        if(getSize() < 0)
        {
            HUDManager.instance.OnGameOver("You Dried!");
            Debug.Log("Player Shrunk");
        }
    }

}
