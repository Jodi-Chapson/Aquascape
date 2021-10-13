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


    void Start()
    {
        FishTankTrigger = this.GetComponent<BoxCollider2D>();
        //minX = FishTankTrigger.bounds.size.x * -1;
        //maxX = FishTankTrigger.bounds.size.x;
        //minY = FishTankTrigger.bounds.size.y * -1;
        //maxY = FishTankTrigger.bounds.size.y;
        waitTime = StartWaitTime;
        MoveSpot = new GameObject();
        MoveSpotTransform = MoveSpot.transform;

        DetermineMoveSpot(MoveSpotTransform);

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
}
