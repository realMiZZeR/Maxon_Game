using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    bool firstOpen = true;
    GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            if (PlayerPrefs.HasKey("AchievementChest") && PlayerPrefs.GetInt("AchievementChest") > 0)
            {
                GameObject chestPanel = GameObject.Find("Canvas/Achievements/AchievementsPanel/Chest");
                //chestPanel.SetActive(true);
            }
    }

    void Update()
    {
        
    }

    private void ResetAchv()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Chest()
    {
        if (firstOpen)
        {
            panel = GameObject.Find("Main Camera/Canvas/Achievement");
            Transform text = panel.transform.Find("Text");
            text.GetComponent<Text>().text = "Первый сундук";
            panel.SetActive(true);

            PlayerPrefs.SetInt("AchievementChest", 1);
            PlayerPrefs.Save();
            StartCoroutine(HideAchievement());
        }
    }
    
    IEnumerator HideAchievement()
    {
        yield return new WaitForSeconds(2f);
        firstOpen = false;
        panel.SetActive(false);
    }
    
}
