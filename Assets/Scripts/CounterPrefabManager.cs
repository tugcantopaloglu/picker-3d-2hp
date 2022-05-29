using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterPrefabManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _infoTxt = null;
    [SerializeField] private int _counterNeedsObject = 0;
    public int CounterNeedsObject
    {
        get
        {
            return _counterNeedsObject;
        }
    }

    private void Start()
    {
        _infoTxt.text = "0 / " + _counterNeedsObject;
    }

    //Counting objects brought by the player
    private void OnTriggerEnter(Collider other)
    {
        CounterManager.Instance.ObjectCount++;
        _infoTxt.text = CounterManager.Instance.ObjectCount + " / " + _counterNeedsObject;
        Destroy(other.gameObject, 0.5f);
    }
}
