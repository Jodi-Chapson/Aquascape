using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private BoxCollider2D FishTankTrigger;
    private GameObject MoveSpot;
    public Transform MoveSpotTransform;

    public float minX;
    public float maxX;
    public float maxY;
    public float minY;

    public float Speed;
    public float waitTime;
    public float StartWaitTime;

    public float scaleX;


    void Start()
    {
        FishTankTrigger = GameObject.Find("Tank01").GetComponent<BoxCollider2D>();
        minX = FishTankTrigger.bounds.min.x;
        maxX = FishTankTrigger.bounds.max.x;
        minY = FishTankTrigger.bounds.min.y;
        maxY = FishTankTrigger.bounds.max.y;
        waitTime = StartWaitTime;
        MoveSpot = new GameObject();
        MoveSpotTransform = MoveSpot.transform;
        scaleX = this.transform.localScale.x;

        DetermineMoveSpot(MoveSpotTransform);
        FlipFish(MoveSpotTransform);

    }


    void Update()
    {
        MoveFish(MoveSpotTransform);
        if (Vector2.Distance(transform.position, MoveSpotTransform.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                Destroy(MoveSpot);
                //MoveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                //FlipFish();
                MoveSpot = new GameObject();
                MoveSpotTransform = MoveSpot.transform;

                DetermineMoveSpot(MoveSpotTransform);

                FlipFish(MoveSpotTransform);
                


                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void MoveFish(Transform movespot)
    {
        transform.position = Vector2.MoveTowards(transform.position, movespot.position, Speed * Time.deltaTime);
    }

    private Transform DetermineMoveSpot(Transform movespot)
    {
        float xPos = Random.Range(minX, maxX);
        float yPos = Random.Range(minY, maxY);
        movespot.position = new Vector2(xPos, yPos);
        return movespot;
    }

    public void FlipFish(Transform movespot)
    {
        if (movespot.position.x < this.transform.position.x) //the new location is towards the left of the fish
        {
            this.transform.localScale = new Vector3(scaleX, this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (movespot.position.x > this.transform.position.x) //the new location is towards the right of the fish
        {
            this.transform.localScale = new Vector3(-scaleX, this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
