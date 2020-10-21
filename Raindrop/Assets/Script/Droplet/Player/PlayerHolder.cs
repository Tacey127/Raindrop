using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    [SerializeField] GameObject player;

    #region singleton

    public static PlayerHolder instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion

    public float getSize()
    {
        return transform.localScale.x;
    }
}
