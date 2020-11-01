using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

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

    public GameInfo info = null;
    private void Start()
    {
        OnStartGame();
    }
    public void OnStartGame()
    {
        Instantiate(info.themeSet.background, Vector3.zero, quaternion.identity);
        Instantiate(info.themeSet.playerObject, Vector3.zero, quaternion.identity);
    }

    #region Score

    [Header("Score")]
    int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText = null;

    public void UpdateScoreUI(int amount)
    {
        currentScore += amount;
        scoreText.text = currentScore.ToString();
    }

    #endregion

    #region GameOver

    [Header("Game Over")]

    [SerializeField] GameObject gameOverScreen = null;
    [SerializeField] TextMeshProUGUI gameOverText = null;
    [SerializeField] TextMeshProUGUI gameOverScoreText = null;
    [SerializeField] TextMeshProUGUI gameOverScoreAmount = null;

    public void OnGameOver(string reason = "No Game Over Reason!")
    {
        Debug.Log(reason);
        PauseGame();

        gameOverScreen.SetActive(true);
        gameOverText.text = reason;
        gameOverScoreAmount.text = currentScore.ToString();

        if(info.CompareBestScore(currentScore))
        {
            gameOverScoreText.text = "New High Score!";
        }
        else
        {
            gameOverScoreText.text = "Score";
        }

    }

    #endregion

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
        ResumeGame();
        SceneManager.LoadScene("StartScene");
    }
}
