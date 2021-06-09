using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MainMenuWindow : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("startBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.CharSelect); };
        transform.Find("quitBtn").GetComponent<Button_UI>().ClickFunc = () => { Application.Quit(); };
    }
}
