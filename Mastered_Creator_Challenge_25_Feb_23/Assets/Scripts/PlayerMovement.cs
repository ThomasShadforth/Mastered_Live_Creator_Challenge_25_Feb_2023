using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerActionMap _input;
    Rigidbody _rb;
    Vector2 _moveInput;

    public float speed;

    public float rotationSmooth;
    float currSmoothVelocity;

    PlayerBase _base;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = new PlayerActionMap();
        _input.Player.Enable();
        _base = FindObjectOfType<PlayerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_base.gameEnded)
        {
            _rb.velocity = Vector3.zero;
            return;
        }

        _moveInput = _input.Player.PlayerMove.ReadValue<Vector2>();


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 direction;

        direction = new Vector3(_moveInput.x, 0, _moveInput.y);



        if (direction.magnitude != 0)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currSmoothVelocity, rotationSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        _rb.velocity = new Vector3(direction.x * speed, _rb.velocity.y, direction.z * speed);
        
    }
}
