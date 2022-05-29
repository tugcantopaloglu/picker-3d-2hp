using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    //stop player at the counter
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MouseMovement.Instance.ForwardSpeed = 0;
            MouseMovement.Instance.MouseSpeed = 0;
        }
    }
}
