using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class MyPlayerController : MonoBehaviour
{
    private Vector2 _moveDirection;
    [SerializeField] private bool _isGround = true;
    
    private Vector2 _startPosition;
    
    private float _speed = 5.0f;
    [SerializeField] private Animator animator;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        bool hasControl = (_moveDirection != Vector2.zero) && _isGround;
         
        if (_isGround == false)
        {
            transform.position = _startPosition;
            _isGround = true;
        }
        
        if (hasControl)
        {
            transform.Translate(_moveDirection * (_speed * Time.deltaTime));
        }


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if(input != null)
        {
            _moveDirection = new Vector2(input.x, input.y);
            Debug.Log($"UNITY_EVENTS : {input.magnitude}");
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGround = false;
        }
    }
}
