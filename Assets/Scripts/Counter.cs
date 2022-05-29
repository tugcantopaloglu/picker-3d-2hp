using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    //text info
    [SerializeField] private TMP_Text _infoTxt = null;
    //object count
    [SerializeField] private int _checkpointNeedsObject = 0;
    public int CheckPointNeedsObject
    {
        get
        {
            return _checkpointNeedsObject;
        }
    }

    private void Start()
    {
        _infoTxt.text = "0 / " + _checkpointNeedsObject;
    }

    //count
    private void OnTriggerEnter(Collider other)
    {
        CounterManager.Instance.ObjectCount++;
        _infoTxt.text = CounterManager.Instance.ObjectCount + " / " + _checkpointNeedsObject;
    }
}
