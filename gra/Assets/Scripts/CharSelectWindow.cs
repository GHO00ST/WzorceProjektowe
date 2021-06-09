using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System;
using CodeMonkey;

public class CharSelectWindow : MonoBehaviour
{
    private Text PointsAmount;
    private string input;
    private void Awake()
    {
        //ResetPoints();
        int point = GetPoints();
        PointsAmount = transform.Find("PointsAmount").GetComponent<Text>();
        transform.Find("mainMenuBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.MainMenu); };
        transform.Find("player1").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene);  };
        transform.Find("player2").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene1);
            }
        };
        transform.Find("player3").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene2);
            }
        };
        transform.Find("player4").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene3);
            }
        };
        transform.Find("player5").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene4);
            }
        };
        transform.Find("player6").GetComponent<Button_UI>().ClickFunc = () => {
            if (point >= 10)
            {
                SubPoints();
                Loader.Load(Loader.Scene.GameScene5);
            }
        };
    }

    private void Start()
    {
        PointsAmount.text = "Ilość monet: " + GetPoints().ToString();
    }

    public static int GetPoints()
    {
        return PlayerPrefs.GetInt("Points");
    }

    public void AddPoints(string wpisane)
    {
        input = wpisane;    
        int submit;
        int.TryParse(input, out submit);
        if(submit == 0)
        {
            CMDebug.TextPopupMouse("Wprowadzono nieprawidłowy kod.");
        }
        else if (submit % 13 == 0 && submit % 17 == 0 && submit % 19 == 0 && submit % 5 == 0)
        {
            int point = PlayerPrefs.GetInt("Points");
            point += 100;
            PlayerPrefs.SetInt("Points", point);
            PlayerPrefs.Save();
            Loader.Load(Loader.Scene.CharSelect);
        } 
        else
        {
            CMDebug.TextPopupMouse("Wprowadzono nieprawidłowy kod.");
        }
    }

    public static void SubPoints()
    {
        int point = PlayerPrefs.GetInt("Points");
        point -= 10;
        PlayerPrefs.SetInt("Points", point);
        PlayerPrefs.Save();
    }
    public static void ResetPoints()
    {
        PlayerPrefs.SetInt("Points", 0);
        PlayerPrefs.Save();
    }

}
