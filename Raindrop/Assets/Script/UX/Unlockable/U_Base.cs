using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UnlockBase", menuName = "Unlock/Base")]
public class U_Base: ScriptableObject
{
    //UI
    public bool locked;
    public bool chosen;
    public bool hidden;

    public Sprite icon;

    public int scoreRequired;

    public ThemeSet themeSet;
}

[Serializable]
public struct ThemeSet
{
    //GAMEPLAY
    public GameObject playerObject;

    public BulletSpawnVarient[] obstacles;

    public GameObject background;
}
