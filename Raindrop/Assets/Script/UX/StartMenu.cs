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
        CameraFade.instance.FadeIn();
        transitionPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SetBackground(_background);
        CameraFade.instance.FadeOut();
        yield return new WaitForSeconds(0.5f);
        transitionPanel.SetActive(false);
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
        StartCoroutine(GameTransition());
    }

    IEnumerator GameTransition()
    {
        CameraFade.instance.FadeIn();
        transitionPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameScene");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
