using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour
{
    #region singleton

    public static CameraFade instance;
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


    [Header("Transition")]
    [SerializeField] GameObject transitionPanel;
    [SerializeField] Image transitionPanelImage;

    [SerializeField] bool startFade = false;

    bool fadeRunning = false;

    void Start()
    {
        if(startFade)
        {
            StartCoroutine(FadeOutOnStart());
        }
    }

    IEnumerator FadeOutOnStart()
    {
        FadeOut();
        yield return new WaitForSeconds(0.5f);
        transitionPanel.SetActive(false);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeBlackOutSquare());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeBlackOutSquare(false));
    }

    IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        if (fadeRunning)
        {
            Debug.LogError("FadeBlackOut IN USE");
        }
        fadeRunning = true;

        Color objectColor = transitionPanelImage.color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (transitionPanelImage.color.a < 1)
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
}
