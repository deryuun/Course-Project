using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _player;
    private bool _isMovingForward = false;
    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;
    private bool _isMovingBack = false;

    private float _speed = 0.05f;

    public void Update()
    {
        if (_isMovingForward)
        {
            transform.Translate(Vector3.forward * _speed, Space.World);
        }
        if (_isMovingLeft)
        {
            transform.Translate(Vector3.left * _speed, Space.World);
        }
        if (_isMovingRight)
        {
            transform.Translate(Vector3.right * _speed, Space.World);
        }
        if (_isMovingBack)
        {
            transform.Translate(Vector3.back * _speed, Space.World);
        }
    }

    public void MoveForward(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            _isMovingForward = true;
        } else if (callbackContext.canceled)
        {
            _isMovingForward = false;
        }
    }

    public void MoveLeft(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            _isMovingLeft = true;
        } else if (callbackContext.canceled)
        {
            _isMovingLeft = false;
        }
    }
    public void MoveRight(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            _isMovingRight = true;
        } else if (callbackContext.canceled)
        {
            _isMovingRight = false;
        }
    }
    public void MoveBack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            _isMovingBack = true;
        } else if (callbackContext.canceled)
        {
            _isMovingBack = false;
        }
    }
}