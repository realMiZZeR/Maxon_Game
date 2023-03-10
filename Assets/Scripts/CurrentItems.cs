using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentItems : MonoBehaviour
{
    GameObject _camera;
    Transform coinText, keyText;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        coinText = _camera.transform.Find("Canvas/coins_number");
        keyText = _camera.transform.Find("Canvas/keys_number");
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("CurrentCoins", 0);
            PlayerPrefs.SetInt("CurrentKeys", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        coinText.GetComponent<Text>().text = PlayerPrefs.GetInt("CurrentCoins").ToString();     
        keyText.GetComponent<Text>().text = PlayerPrefs.GetInt("CurrentKeys").ToString();
    }
}
