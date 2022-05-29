using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//controls every draggable object Y position
public class Objects : MonoBehaviour
{
    private Rigidbody _rb;
    private float _startPosY;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startPosY = transform.position.y;
    }

    void Update()
    {
        if (transform.position.y > _startPosY)
        {
            _rb.MovePosition(new Vector3(transform.position.x, _startPosY, transform.position.z));
        }
    }
}
