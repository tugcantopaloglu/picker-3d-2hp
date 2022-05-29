using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public static MouseMovement Instance;

    [SerializeField] private float _forwardSpeed = 3f;
    [SerializeField] private float _mouseSpeed = 10f;
    private Rigidbody _rb;
    private Vector3 _moveVector;

    private Vector3 _mouseInput;
    private float _objXPos;
    private float _movZ;
    public float ForwardSpeed
    {
        get
        {
            return _forwardSpeed;
        }

        set
        {
            _forwardSpeed = value;
        }
    }


    public float MouseSpeed
    {
        get
        {
            return _mouseSpeed;
        }

        set
        {
            _mouseSpeed = value;
        }
    }



    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnMouseDrag()
    {
        _mouseInput.x = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        _moveVector.z = transform.position.z + (_forwardSpeed * Time.fixedDeltaTime);

        _moveVector.x = transform.position.x + (_mouseInput.x * _mouseSpeed * Time.fixedDeltaTime);

        //to stay on the road
        if (_moveVector.x > 0.8f)
        {
            _moveVector.x = 0.8f;
        }
        else if (_moveVector.x < -2.4f)
        {
            _moveVector.x = -2.4f;
        }

        _rb.MovePosition(_moveVector);
    }
}
