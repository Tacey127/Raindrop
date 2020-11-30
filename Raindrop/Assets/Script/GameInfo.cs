using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInfo", menuName = "Data/GameInfo")]
public class GameInfo : ScriptableObject
{
    //UI
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
    //GAMEPLAY
    public ThemeSet themeSet;
    
    #endregion

    //UX
    [SerializeField] U_Base chosenSet;
    public void SetThemeSet(U_Base newSet)
    {
        chosenSet.chosen = false;
        newSet.chosen = true;
        chosenSet = newSet;
        themeSet = chosenSet.themeSet;
    }

}

