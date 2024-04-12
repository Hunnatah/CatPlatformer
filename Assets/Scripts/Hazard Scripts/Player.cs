using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool touchHazard = false;
    public Vector2 spawn;

    private void Start()
    {
        spawn = transform.position;
    }

    private void Update()
    {
        if (touchHazard == true)
        {
            transform.position = spawn;
            touchHazard = false;
        }
    }

}
