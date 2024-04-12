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
    public Material greenMaterial;
    public Material orgMaterial;
    float timer = 0;
    public float delay = 3f;
    public GameObject platformPrefab;

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
                    gameObject.GetComponent<Renderer>().material = orgMaterial;
                    timer = 0;
                    state = PlatformState.AtPointA;
                }
                break;

            case PlatformState.AtPointA:
                timer += Time.deltaTime;

                if (timer > delay)
                {
                    gameObject.GetComponent<Renderer>().material = greenMaterial;
                    state = PlatformState.PointB;
                }
                break;

            case PlatformState.PointB:
                OpenTheDoor(closedPosition);

                if (Vector3.Distance(transform.position, closedPosition) < 0.01f)
                {
                    gameObject.GetComponent<Renderer>().material = orgMaterial;
                    timer = 0;
                    state = PlatformState.AtPointB;
                }
                break;

            case PlatformState.AtPointB:
                timer += Time.deltaTime;

                if (timer > delay)
                {
                    gameObject.GetComponent<Renderer>().material = greenMaterial;
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
