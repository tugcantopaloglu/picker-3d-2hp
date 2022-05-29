using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script pushes object to the counter
public class PlayerBackCollider : MonoBehaviour
{
    [SerializeField] private GameObject _frontCollider;
    private Vector3 _startPos;
    private bool _isRestart = false;

    void Start()
    {
        _startPos.x = transform.localPosition.x;
        _startPos.y = transform.localPosition.y;
        _startPos.z = transform.localPosition.z;
    }

    void FixedUpdate()
    {
        if (MouseMovement.Instance.ForwardSpeed == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _frontCollider.transform.position, Time.fixedDeltaTime * 1f);
            _isRestart = true;
        }

        if (_isRestart)
        {
            Invoke("RestartPosition", 2f);
        }
    }
    //restart
    private void RestartPosition()
    {
        transform.localPosition = new Vector3(_startPos.x, _startPos.y, _startPos.z);
        _isRestart = false;
    }
}
