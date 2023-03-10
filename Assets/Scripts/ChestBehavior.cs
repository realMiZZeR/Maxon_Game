using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBehavior : MonoBehaviour
{
    private Animator animator;

    GameObject _camera;
    Transform textBlock;
    private Achievements achv;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        achv = GameObject.FindObjectOfType(typeof(Achievements)) as Achievements;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            openChest();
        }
    }

    void openChest()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        textBlock = _camera.transform.Find("Canvas/keys_number");

        int keys = Convert.ToInt32(textBlock.GetComponent<Text>().text);
        if (keys > 0)
        {
            animator.SetInteger("state", 1);
            keys -= 1;
            PlayerPrefs.SetInt("CurrentKeys", keys);
            achv.Chest(); // get from class "Achievements" function Chest()
        }
    }
}
