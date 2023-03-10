using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    // player's acceleration
    [Header("Player velocity")]
        public int xVelocity = 5;
        public int yVelocity = 8;

    // getting ground and character colliders
    [SerializeField] private LayerMask Ground;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D boxcoll;
    private CapsuleCollider2D capsulecoll;

    // character's sprite
    private SpriteRenderer spriteRenderer;

    // character's animation
    private Animator animatorComponent;

    private enum AnimationState { idle, running, jumping, falling }; // 0, 1, 2, 3
    private AnimationState currentAnimationState = AnimationState.idle;

    private float jumpInput, moveInput;

    GameObject _camera;
    Transform text;


    void Start()
    {
        // object's body
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        // getting for collision
        boxcoll = gameObject.GetComponent<BoxCollider2D>();
        // getting for capsule collision
        capsulecoll = gameObject.GetComponent<CapsuleCollider2D>();
        // getting character's sprite
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // getting character's animation
        animatorComponent = gameObject.GetComponent<Animator>();

        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        text = _camera.transform.Find("Canvas/coins_number");
}


    void Update()
    {
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        updatePlayerPosition();
    }

    
    private void updatePlayerPosition()
    {
        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        GameObject camera = GameObject.Find("Main Camera");
        CameraBehavior cameraBehavior = camera.GetComponent<CameraBehavior>();

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (_rigidbody.transform.position.y < cameraBehavior.minY - 6)
            {
                destroyCharacter();
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if(_rigidbody.transform.position.y < cameraBehavior.minY - 6)
            {
                destroyCharacter();
            }
        }
        

        setAnimationState();
    }

    public void destroyCharacter()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        GameObject _gameObject = GameObject.Find("Main Camera/Canvas/Death Panel");
        _gameObject.SetActive(true);
    }

    public void OnJumpButtonDown()
    {
        if (boxcoll.IsTouchingLayers(Ground))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, yVelocity);
        }  
    }

    public void OnLeftButtonDown()
    {
        _rigidbody.velocity = new Vector2(-xVelocity, _rigidbody.velocity.y);
        spriteRenderer.flipX = true;
    }

    public void OnRightButtonDown()
    {
        _rigidbody.velocity = new Vector2(xVelocity, _rigidbody.velocity.y);
        spriteRenderer.flipX = false;
    }

    public void OnButtonDown()
    {
        if (boxcoll.IsTouchingLayers(Ground))
        {
            _rigidbody.velocity = Vector2.zero; // disable inertia
        }
    }

    private void setAnimationState()
    {
        // character gets ground
        if (boxcoll.IsTouchingLayers(Ground))
        {
            // При помощи Mathf.Abs получаем модуль значения ускорения (если бежим влево, оно отрицательное)
            // if x > 0 (speed) then run
            if (Mathf.Abs(_rigidbody.velocity.x) > 0.1f)
            {
                currentAnimationState = AnimationState.running;
            }
            else
            {
                // Если нет - стоим на месте  
                currentAnimationState = AnimationState.idle;
            } 
        }
        else
        {
            currentAnimationState = AnimationState.jumping;

            if (currentAnimationState == AnimationState.jumping)
            {
                // if boost jump < 0 then animation falling
                if (_rigidbody.velocity.y < .1f)
                {
                    currentAnimationState = AnimationState.falling;
                }
            }
            else if (currentAnimationState == AnimationState.falling)
            {
                // if character gets ground then stay idle
                if (boxcoll.IsTouchingLayers(Ground))
                {
                    currentAnimationState = AnimationState.idle;
                }
            }
        }

        // change state's value
        animatorComponent.SetInteger("state", (int)currentAnimationState);
    }
}
