using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hazard : MonoBehaviour
{ 
    public Player player;
    public WallHazard movingHazard;
    public int hazardValue; // 0 is static hazard && 1 is moving hazard

    private void OnTriggerEnter(Collider other)
    {
        if (hazardValue == 0 || hazardValue == 1)
        {
            player.touchHazard = true;
            movingHazard.throwBack = true;
            if (hazardValue == 0)
            {
                Debug.Log("Touched Static Hazard");
            }
            else
            {
                Debug.Log("Touched Moving Hazard");
            }
        }
    }
}
