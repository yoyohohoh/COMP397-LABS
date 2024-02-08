using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

//To make sure the object contains the required components
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    COMP397LABS _inputs;
    Vector2 _move;

    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;

    [Header("Movements")]
    [SerializeField] float _speed;
    [SerializeField] float _gravity = -30.0f;
    [SerializeField] float _jumpHeight = 3.0f;
    [SerializeField] Vector3 _velocity;

    [Header("Ground Detection")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundRadius = 0.5f;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] bool _isGrounded;

    [Header("Respawn Locations")]
    [SerializeField] Transform _respawn;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _inputs = new COMP397LABS();
        _inputs.Enable();

        //Debug for player location
        //_inputs.Player.Move.performed += context => SendMessage(context);

        //Move when pressing key
        _inputs.Player.Move.performed += context => _move = context.ReadValue<Vector2>();
        //Stop when not pressing key, otherwise player will keep moving to the last direciton
        _inputs.Player.Move.canceled += context => _move = Vector2.zero;

        //Jump when pressing key
        _inputs.Player.Jump.performed += context => Jump();
    }

    //same thing as beloe but short form
    private void OnEnable() => _inputs.Enable();
    
    //same thing as above but long form
    private void OnDisable()
    {
        _inputs.Disable();
    }

    void FixedUpdate()
    {
        //basic movement and gravity setting
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
        if(_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }
        Vector3 movement = new Vector3(_move.x, 0.0f, _move.y) * _speed * Time.fixedDeltaTime;
        _controller.Move(movement);
        _velocity.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_velocity * Time.fixedDeltaTime);
    }

    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }

    void Jump()
    {
        if(_isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //death zone
        Debug.Log($"Triggering with {other.gameObject.tag}");
        if(other.gameObject.CompareTag("death"))
        {
            _controller.enabled = false;
            transform.position = _respawn.position;
            _controller.enabled = true;
        }
    
    }

    private void SendMessage(InputAction.CallbackContext context)
    {
        Debug.Log($"Move Performed x = {context.ReadValue<Vector2>(). x}, y = {context.ReadValue<Vector2>(). y}");
    }
    
}
