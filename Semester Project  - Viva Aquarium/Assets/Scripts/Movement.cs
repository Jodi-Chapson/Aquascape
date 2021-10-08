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

    public float scaleX;

    
    void Start()
    {
        waitTime = StartWaitTime;
        scaleX = this.transform.localScale.x;


        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); //Free movement for the fish within its boundaries
        FlipFish();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                FlipFish();
               

                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }


    public void FlipFish()
    {
        if (moveSpots.position.x < this.transform.position.x) //the new location is towards the left of the fish
        {
            this.transform.localScale = new Vector3(scaleX, this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (moveSpots.position.x > this.transform.position.x) //the new location is towards the right of the fish
        {
            this.transform.localScale = new Vector3(-scaleX, this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
