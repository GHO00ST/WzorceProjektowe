using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{
    private Text ScoreText;
    private Text highscoreText;

    private void Awake()
    {
        ScoreText = transform.Find("ScoreText").GetComponent<Text>();
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();

        transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.CharSelect); };
        transform.Find("mainMenuBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.MainMenu); };
    }

    private void Start()
    {
        Hide();
        Bird.GetInstance().OnDied += Bird_OnDied;
    }

    private void Bird_OnDied(object sender, System.EventArgs e)
    {
        ScoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
        if (Level.GetInstance().GetPipesPassedCount() >= Score.GetHighscore())
        {
            highscoreText.text = "Nowy najlepszy wynik: " + Score.GetHighscore().ToString();
        } 
        else
        {
            highscoreText.text = "Najlepszy wynik: " + Score.GetHighscore().ToString();
        }
        
        Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
