using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText; 
    public int score;

    public GameObject titleScreen;
    public void updateLives(int currentLives)
    {
        Debug.Log("Current Lives : " + currentLives); 
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void updateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        scoreText.text = "Score: ";
    }
}
