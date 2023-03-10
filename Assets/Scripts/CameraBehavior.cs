using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [Header("GameObject")]
        public Transform _gameObject;
    [Header("Camera position restrictions")]
        public float minY;
        public float maxY;
        public float minX;
        public float maxX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        try
        {
            transform.position = new Vector3(
                Mathf.Clamp(_gameObject.position.x, minX, maxX),
                Mathf.Clamp(_gameObject.position.y, minY, maxY),
                transform.position.z
                );

        }
        catch
        {
            _gameObject = null;     
        }
    }
}
