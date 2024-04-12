using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHazard : MonoBehaviour
{
    [SerializeField] private float hazardSpeed;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 position;
    [SerializeField] private Vector2 startPosition;
    public bool throwBack = false;


    void Start()
    {
        position.x = transform.position.x;
        startPosition = transform.position;
    }

    void Update()
    {
       position.y = player.transform.position.y;

        if (throwBack == true)
        {
            position = startPosition;
            throwBack = false;
        }

       MoveForward();
    }

    private void MoveForward()
    {
        position.x += hazardSpeed * Time.deltaTime;
        transform.position = position;
    }
}
