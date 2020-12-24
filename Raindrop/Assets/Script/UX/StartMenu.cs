using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    #region singleton

    public static StartMenu instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    #endregion


    GameObject recentBackground = null;

    [Header("Transition")]
    [SerializeField] GameObject transitionPanel;
    [SerializeField] Image transitionPanelImage;

    [Header("Data")]
    public GameInfo gameInfo;

    private void Start()
    {
        SetBackground(gameInfo.themeSet.background);
    }

    public void TransitionToTheme()
    {
        StartCoroutine(ThemeTransition(gameInfo.themeSet.background));
    }

    IEnumerator ThemeTransition(GameObject _background)
    {
        StartCoroutine(FadeBlackOutSquare());
        transitionPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SetBackground(_background);
        StartCoroutine(FadeBlackOutSquare(false));
        yield return new WaitForSeconds(0.5f);
        transitionPanel.SetActive(false);
    }

    bool fadeRunning = false;

    IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        if(fadeRunning)
        {
            Debug.LogError("FadeBlackOut IN USE");
        }
        fadeRunning = true;

        Color objectColor = transitionPanelImage.color;
        float fadeAmount;
        
        if(fadeToBlack)
        {
            while(transitionPanelImage.color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                transitionPanelImage.color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (transitionPanelImage.color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                transitionPanelImage.color = objectColor;
                yield return null;
            }
        }

        fadeRunning = false;
    }

    void SetBackground(GameObject _chosenBackground)
    {
        if(recentBackground != null)
        {
            Destroy(recentBackground);
        }

        recentBackground = Instantiate(_chosenBackground);

    }



    public void BeginGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
