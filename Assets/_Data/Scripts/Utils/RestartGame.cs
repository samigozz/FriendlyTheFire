using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using Update = Unity.VisualScripting.Update;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private IntValue playerLives;

    [SerializeField] private GameObject GameOverPanel;
    
    private void Update()
    {
        if (playerLives.runtimeLives == 0)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
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
