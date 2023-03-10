using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour   
{

    [Range(0.1f, 1.0f)] public float verticalMovementDistance = 0.30f;
    private float initialCoinVerticalPosition;

    private SpriteRenderer spriteRenderer;
    private static int coin;
    // Start is called before the first frame update
    void Start()
    {
        initialCoinVerticalPosition = transform.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCoinVerticalPosition();
    }
    void CalculateCoinVerticalPosition()
    {
        float coinVerticalPosition = Mathf.Lerp(
            initialCoinVerticalPosition - (verticalMovementDistance / 2),
            initialCoinVerticalPosition + (verticalMovementDistance / 2),
            Mathf.PingPong(Time.time, 1)
            );

        transform.position = new Vector3(transform.position.x, coinVerticalPosition, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool _collected = false;
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Transform text = camera.transform.Find("Canvas/coins_number");
        if (collision.gameObject.name == "Player" && !_collected)
        {
            spriteRenderer.sortingOrder = 3;

            coin += 1;
            PlayerPrefs.SetInt("CurrentCoins", coin);
            PlayerPrefs.Save();

            if (collision.name == "Coin (3)")
            {
                Debug.Log(collision.name);
                StartCoroutine(SelfDestrict());
            }           
            else
            {
                this.gameObject.SetActive(false);
                Destroy(gameObject);
            }

        }
    }

    IEnumerator SelfDestrict()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
