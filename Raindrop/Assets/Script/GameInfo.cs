using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInfo", menuName = "Data/GameInfo")]
public class GameInfo : ScriptableObject
{
    [SerializeField]int bestScore;

    public int GetBestScore()
    {
        return bestScore;
    }

    public bool CompareBestScore(int _score)
    {
        if(_score > bestScore)
        {
            bestScore = _score;
            return true;
        }
        return false;
    }

    #region GameInfo

    Sprite chosenSkin;
    Material chosenBackground;

    #endregion



    //list skins
    List<Tuple<Unlockable, Sprite>> skinList;

    //list backgrounds
    List<Tuple<Unlockable, Material>> backgroundList;
}

struct Unlockable
{
    bool locked;//button to unlock
    bool unlocled;
}
