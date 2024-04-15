using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LevelChange : MonoBehaviour
{
    [SerializeField] private GUIManager _sceneChange;
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter(Collider other)
    {
        _sceneChange.ChangeScene(_sceneName);
    }
}
