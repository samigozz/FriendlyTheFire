using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private IntValue playerLives;

    private float backgroundAlpha;
    private float elapsedTime;
    private float alphaAmount = 0.005f;

    [SerializeField]
    private GameObject GameOverPanel;
    
    private void Update()
    {
        if (playerLives.runtimeLives == 0)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            
            elapsedTime += alphaAmount;
            backgroundAlpha = Mathf.Lerp(0, 1, elapsedTime);
            Image panelImage = GameOverPanel.GetComponent<Image>();
            Color panelColor = panelImage.color;
            panelColor.a = backgroundAlpha;
            panelImage.color = panelColor;
        }
    }

    public void RestarGame()
    {
        playerLives.runtimeLives = 3;
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("Movement");
    }
}
