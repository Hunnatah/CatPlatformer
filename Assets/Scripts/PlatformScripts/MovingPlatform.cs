using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovingPlatform;

public class MovingPlatform : MonoBehaviour
{
    public enum PlatformState
    {
        PointA, 
        AtPointA,
        PointB,
        AtPointB
    }

    public PlatformState state;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    public float speed = 5f;
    public Vector3 deltaPosition = new Vector3(0,0,0);  

    float timer = 0;
    public float delay = 3f;


    private void Start()
    {
        state = PlatformState.AtPointB;

        closedPosition = transform.position;
        openPosition = transform.position + deltaPosition;
    }

    void Update()
    {

        switch (state)
        {
            case PlatformState.PointA:
                OpenTheDoor(openPosition);

                if (Vector3.Distance(transform.position, openPosition) < 0.01f)
                {
                    timer = 0;
                    state = PlatformState.AtPointA;
                }
                break;

            case PlatformState.AtPointA:
                timer += Time.deltaTime;

                if (timer > delay)
                {
                    state = PlatformState.PointB;
                }
                break;

            case PlatformState.PointB:
                OpenTheDoor(closedPosition);

                if (Vector3.Distance(transform.position, closedPosition) < 0.01f)
                {
                    timer = 0;
                    state = PlatformState.AtPointB;
                }
                break;

            case PlatformState.AtPointB:
                timer += Time.deltaTime;

                if (timer > delay)
                {
                    state = PlatformState.PointA;
                }

                break;

        }

    }

    public void OpenTheDoor(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

}
