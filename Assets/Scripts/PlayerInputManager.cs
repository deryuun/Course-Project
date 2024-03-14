using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _player;
    private DialogueManager _manager;
    private bool _isMovingForward = false;
    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;
    private bool _isMovingBack = false;
    private bool _submitPressed = false;
    private bool _interactPressed = false;

    private float _speed = 0.05f;

    public void Awake()
    {
        _manager = DialogueManager.GetInstance();
    }

    public void FixedUpdate()
    {
        if (_manager.dialogueIsPlaying)
        {
            return;
        }
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
    
    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactPressed = true;
        }
        else if (context.canceled)
        {
            _interactPressed = false;
        } 
    }
    public void Submit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _submitPressed = true;
        }
        else if (context.canceled)
        {
            _submitPressed = false;
        } 
    }

    public bool GetSubmitPressed() 
    {
        bool result = _submitPressed;
        _submitPressed = false;
        return result;
    }
    
    public bool GetInteractPressed() 
    {
        bool result = _interactPressed;
        _interactPressed = false;
        return result;
    }
}