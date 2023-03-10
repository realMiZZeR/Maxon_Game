using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMace : MonoBehaviour
{
    [Header("Y")]
        public int moveY;

    private float initialVerticalPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialVerticalPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveVerticalPosition();
    }
    void MoveVerticalPosition()
    {
        float enemyVerticalPosition = Mathf.Lerp(
            initialVerticalPosition - (moveY / 6),
            initialVerticalPosition + (moveY / 2),
            Mathf.PingPong(Time.time, 1)
            );

        transform.position = new Vector3(transform.position.x, enemyVerticalPosition, transform.position.z);
    }
}
