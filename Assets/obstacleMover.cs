using UnityEngine;
using System.Collections;

public class obstacleMover : MonoBehaviour
{    
    Quaternion downright;
    Quaternion downleft;
    public float winTimer = 3;
    Vector3 directiongMoving;  
    Vector3 startPoint;
    Quaternion startDirection;


    void Start()
    {
        downright = Quaternion.Euler(0, 125, 0);
        downleft = Quaternion.Euler(0, 250, 0);
        directiongMoving = transform.TransformDirection(0,0,1);
        startPoint = transform.position;
        startDirection = downright;
    }

    void Update()
    {
        winTimer -= Time.deltaTime;
        if (transform.position.y < -4)
        {
            transform.position = startPoint;
            transform.rotation = startDirection;
        }
        if (winTimer <= 0)
        {
            // Right arrow moves southeast
            if (Random.value < 0.5)
            {
                MovePlayer(downright);
            }
            else
            {
                MovePlayer(downleft);
            }
            winTimer = 3;

        }
    }

    
    void MovePlayer(Quaternion rotation)
    {
        transform.rotation = rotation;
        directiongMoving = transform.TransformDirection(0,0,1);
        transform.position += (directiongMoving);
    }
    
    
}