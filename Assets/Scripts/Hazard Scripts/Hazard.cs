using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hazard : MonoBehaviour
{ 
    public Player player;
    public WallHazard movingHazard;
    public int hazardValue; // 0 is static hazard && 1 is moving hazard

    [SerializeField] private GUIManager _stateChange;

    private void OnTriggerEnter(Collider other)
    {
        if (hazardValue == 0 || hazardValue == 1)
        {
            player.touchHazard = true;

            if (movingHazard != null)
            {
                movingHazard.throwBack = true;
            }

            if (hazardValue == 0)
            {
                Debug.Log("Touched Static Hazard");
                _stateChange.ChangeState("Lose");
            }
            else
            {
                Debug.Log("Touched Moving Hazard");
                _stateChange.ChangeState("Lose");
            }
        }
    }
}
