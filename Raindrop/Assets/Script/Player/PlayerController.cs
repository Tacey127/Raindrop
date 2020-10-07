using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DropletBase
{
    #region singleton

    public PlayerController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion

    void AddInput()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
    }

    protected override void RunUpdate()
    {
        AddInput();
        base.RunUpdate();
    }
}
