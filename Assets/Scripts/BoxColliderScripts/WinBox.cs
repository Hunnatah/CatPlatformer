using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WinBox : MonoBehaviour
{
    [SerializeField] private GUIManager _stateChange;

    private void OnTriggerEnter(Collider other)
    {
        _stateChange.ChangeState("Win");
    }
}
