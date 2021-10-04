using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour //This script is for the movement of the fish
{
    public float speed;
    private float waitTime;
    public float StartWaitTime;

    public Transform moveSpots;

    public float minX;
    public float maxX;
    public float maxY;
    public float minY;

    
    void Start()
    {
        waitTime = StartWaitTime;

        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); //Free movement for the fish within its boundaries
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
    
    }
}
