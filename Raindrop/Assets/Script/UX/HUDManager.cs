using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    #region Singleton

    public static HUDManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField] GameInfo info;

    #region Score
    int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public void UpdateScoreUI(int amount)
    {
        currentScore += amount;
        scoreText.text = currentScore.ToString();
    }

    #endregion

    public void OnGameOver(string reason = "No Game Over Reason!")
    {
        Debug.Log(reason);
        PauseGame();

        if(info.CompareBestScore(currentScore))
        {
            //New highscore
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ResetGame()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
