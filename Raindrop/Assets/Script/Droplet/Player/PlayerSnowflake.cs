using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnowflake : PlayerHolder
{
    [SerializeField] Vector3 mousePos = Vector3.zero;

    [SerializeField] float rotationSpeed = 20f;

    [SerializeField] float shrinkage = 0.1f;

    bool isDead = false;//update isnt stopping

    protected override void RunUpdate()
    {
        if (!isDead)
        {

            ShrinkOverTime();
            AddInput();
            RotateSprite(rotationSpeed);
            base.RunUpdate();
        }
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
        spriteHolder.transform.Rotate(0, 0, dir * Time.deltaTime);
    }

    //Collision
    protected override void OnAbsorbed()
    {
        spriteHolder.transform.localScale -= Vector3.one * shrinkage * Time.deltaTime;

        HUDManager.instance.OnGameOver("You Got Absorbed!");
        Debug.Log("Player Absorbed");
        isDead = true;
    }

    void ShrinkOverTime()
    {
        spriteHolder.transform.localScale -= Vector3.one * shrinkage * Time.deltaTime;
        if(getSize() < 0)
        {
            HUDManager.instance.OnGameOver("You Shrunk!");
            Debug.Log("Player Shrunk");
            isDead = true;
        }
    }

}
