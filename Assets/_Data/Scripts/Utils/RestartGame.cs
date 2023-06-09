using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UI.Slider;
using Image = UnityEngine.UI.Image;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private IntValue playerLives;
    [SerializeField]
    private IntValue wood;
    [SerializeField]
    private GameObject FLife;
    [SerializeField]
    private GameObject FCanvas;

    private float backgroundAlpha;
    private float elapsedTime;
    private float alphaAmount = 0.005f;

    [SerializeField]
    private GameObject GameOverPanel;
    
    [SerializeField]
    private GameObject VictoryPanel;
    
    private void Update()
    {
        if (playerLives.runtimeValue == 0 || FLife.gameObject.GetComponent<Slider>().value == 0f)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            FCanvas.SetActive(false);
            
            elapsedTime += alphaAmount;
            backgroundAlpha = Mathf.Lerp(0, 1, elapsedTime);
            Image panelImage = GameOverPanel.GetComponent<Image>();
            Color panelColor = panelImage.color;
            panelColor.a = backgroundAlpha;
            panelImage.color = panelColor;
        }

        if (FLife.gameObject.GetComponent<Slider>().value >= 0.98f)
        {
            VictoryPanel.SetActive(true);
            FCanvas.SetActive(false);
            
            elapsedTime += alphaAmount;
            backgroundAlpha = Mathf.Lerp(0, 1, elapsedTime);
            Image panelImage = VictoryPanel.GetComponent<Image>();
            Color panelColor = panelImage.color;
            panelColor.a = backgroundAlpha;
            panelImage.color = panelColor;
        }
    }

    public void RestarGame()
    {
        playerLives.runtimeValue = 3;
        wood.runtimeValue = 0;
        FLife.gameObject.GetComponent<Slider>().value = 0.5f;
        FCanvas.SetActive(true);
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("MainLevel");
    }
}
