using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBehavior : MonoBehaviour
{
    [Range(0.1f, 1.0f)] public float verticalMovementDistance = 0.30f;
    private float initialCoinVerticalPosition;

    private SpriteRenderer spriteRenderer;
    private static int keys;

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
        Transform text = camera.transform.Find("Canvas/keys_number");
        if (collision.gameObject.tag == "Player" && !_collected)
        {
            spriteRenderer.sortingOrder = 2;

            keys += 1;
            PlayerPrefs.SetInt("CurrentKeys", keys);
            PlayerPrefs.Save();

            StartCoroutine(SelfDestrict());       
        }
    }

    IEnumerator SelfDestrict()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
