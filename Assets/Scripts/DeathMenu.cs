using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    GameObject _gameObject;
    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.Find("Main Camera/Canvas/Death Panel");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
        _gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _gameObject.SetActive(false);
    }
}
