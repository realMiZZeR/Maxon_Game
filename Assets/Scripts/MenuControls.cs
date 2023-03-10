using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    private string playerPath = Path.Combine(Directory.GetCurrentDirectory(), @"Assets\PlayerStats");

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

    // Update is called once per frame
    void Update()
    {
             
    }

    public void PlayPressed()
    {
        //if (PlayerPrefs.HasKey("CurrentScene") && PlayerPrefs.GetInt("CurrentScene") > 0)
        //{
        //    SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
        //}
        //else
        //{
            SceneManager.LoadScene("Level One");
        //}
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Quit pressed");
    }
    public void MainMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
}
