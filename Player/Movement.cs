using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float _moveSpeed = 10f;
    //[SerializeField] private float _runningSpeed = 20;

    [Header("Jump")]
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _gravity = -9.81f;
    
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _isGrounded;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = _controller.isGrounded;
        Move();
        Jump();
    }

    public void Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var movement = new Vector3(x, 0, z);

        _controller.Move(transform.TransformDirection(movement) * _moveSpeed * Time.deltaTime);
        AddGravity();
    }

    public void Jump()
    {
        if (_isGrounded && Input.GetButton("Jump"))
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3 * _gravity);
        }
    }
    
    private void AddGravity()
    {
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2;
        }
        else
        {
            _playerVelocity.y += _gravity * Time.deltaTime;
        }
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}
