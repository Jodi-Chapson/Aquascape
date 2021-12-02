using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    private BoxCollider2D FishTankTrigger;
    private BoxCollider2D FishTankTrigger02;

    public BoxCollider2D SwimmingArea;

    public GameObject MoveSpot;
    public Transform MoveSpotTransform;

    public float minX;
    public float maxX;
    public float maxY;
    public float minY;

    public float fishheight;
    public float fishlength;

    public float minspeed;
    public float maxspeed;
    public float currentSpeed;

    public float speedTime;
    public float MinSpeedTime;
    public float MaxSpeedTime; //just to vary the fishes speed every once in a while
    public float waitTime;
    public float StartWaitTime;

    public float scaleX;
    public bool canMove;

    public GameObject HappinessLevel;            //This is the happiness level indicator
    public GameObject FishPanelGO;
    public bool hasSwimmingArea;

    public string TankName;

    //Save File stuff
    public int Level;
    public float Happiness;
    public string Species;
    public int hometankID;
    public int UpgradePrice;

    void Awake()
    {
        if (!SaveManager.Fish.Contains(this))
        {
            SaveManager.Fish.Add(this);
            GameManager.fish.Add(this.gameObject);
        }
    }

    void Start()
    {
        canMove = true;
        HappinessLevel.SetActive(false);

        FishTankTrigger = GameObject.Find("Tank01").GetComponent<BoxCollider2D>();
        FishTankTrigger02 = GameObject.Find("Tank02").GetComponent<BoxCollider2D>();

        speedTime = Random.Range(MinSpeedTime, MaxSpeedTime);
        waitTime = StartWaitTime;
        currentSpeed = Random.Range(minspeed, maxspeed);
        scaleX = this.transform.localScale.x;
        HappinessLevel.GetComponent<Slider>().value = Happiness;

        //MoveSpot = new GameObject();
        //MoveSpot.transform.position = new Vector2(Random.Range(SwimmingArea.bounds.min.x, SwimmingArea.bounds.max.x), Random.Range(SwimmingArea.bounds.min.y, SwimmingArea.bounds.max.y));
        //MoveSpotTransform = MoveSpot.transform;
        //DetermineMoveSpot(MoveSpotTransform);
        //FlipFish(MoveSpotTransform);
    }

    void OnMouseOver()
    {
        HappinessLevel.SetActive(true);         // Only Appear when mouse hovers over the fish
    }

    void OnMouseExit()
    {
        HappinessLevel.SetActive(false);
    }

    void Update()
    {
        if (speedTime <= 0)
        {
            VarySpeed();
        }
        else
        {
            speedTime -= Time.deltaTime;
        }

        if (hasSwimmingArea)
        {
            MoveSpot = new GameObject();
            MoveSpot.transform.position = new Vector2(Random.Range(SwimmingArea.bounds.min.x, SwimmingArea.bounds.max.x), Random.Range(SwimmingArea.bounds.min.y, SwimmingArea.bounds.max.y));
            MoveSpotTransform = MoveSpot.transform;
            DetermineMoveSpot(MoveSpotTransform);
            FlipFish(MoveSpotTransform);
            hasSwimmingArea = false;
        }

        //moves fish
        MoveFish(MoveSpotTransform);

        //checks if fish is new movespot position
        if (Vector2.Distance(transform.position, MoveSpotTransform.position) < 0.3f && !hasSwimmingArea)
        {
            if (waitTime <= 0)
            {
                Destroy(MoveSpot);

                MoveSpot = new GameObject();
                MoveSpotTransform = MoveSpot.transform;

                DetermineMoveSpot(MoveSpotTransform);

                FlipFish(MoveSpotTransform);


                float random = Random.Range(StartWaitTime - 2, StartWaitTime);
                waitTime = random;
            }
            else
            {
                waitTime -= Time.deltaTime;
                currentSpeed = minspeed;
            }

        }

        HappinessLevel.GetComponent<Slider>().value = Happiness;

        CheckCursor();

        if (this.transform.position.x >= -7.5 && this.transform.position.x <= 7.3)
        {
            TankName = "Tank01";
            minX = FishTankTrigger.bounds.min.x + fishlength;
            maxX = FishTankTrigger.bounds.max.x - fishlength;
            minY = FishTankTrigger.bounds.min.y + fishheight;
            maxY = FishTankTrigger.bounds.max.y - fishheight;
        }

        else if (this.transform.position.x >= 9 && this.transform.position.x <= 23)
        {
            TankName = "Tank02";
            minX = FishTankTrigger02.bounds.min.x + fishlength;
            maxX = FishTankTrigger02.bounds.max.x - fishlength;
            minY = FishTankTrigger02.bounds.min.y + fishheight;
            maxY = FishTankTrigger02.bounds.max.y - fishheight;
        }
    }

    private void MoveFish(Transform movespot)
    {
        //moves the fish towards the movespot transform position

        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, movespot.position, currentSpeed * Time.deltaTime);
        }
    }

    private Transform DetermineMoveSpot(Transform movespot)
    {
        //choose a position within the range of the home tank
        float xPos = Random.Range(SwimmingArea.bounds.min.x + fishlength, SwimmingArea.bounds.max.x - fishlength);
        float yPos = Random.Range(SwimmingArea.bounds.min.y + fishheight, SwimmingArea.bounds.max.y - fishheight);
        movespot.position = new Vector2(xPos, yPos);
        return movespot;
    }

    public void FlipFish(Transform movespot)
    {
        //flips the fish gameobject based on their position in relation to the movespot position

        if (movespot.position.x < this.transform.position.x) //the new location is towards the left of the fish
        {
            this.transform.localScale = new Vector3(scaleX, this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (movespot.position.x > this.transform.position.x) //the new location is towards the right of the fish
        {
            this.transform.localScale = new Vector3(-scaleX, this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    public void CheckCursor()
    {
        //checks the position of the players cursor

        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousepos.x > maxX || mousepos.x < minX || mousepos.y > maxY || mousepos.y < minY)
        {
            return;
        }


        Vector2 currentfishpos = this.transform.position;

        float distance = Vector2.Distance(mousepos, currentfishpos);

        if (distance < 2f)
        {
            MoveSpotTransform.position = mousepos;
            currentSpeed = maxspeed;
            FlipFish(MoveSpotTransform);
        }
    }

    public void VarySpeed()
    {
        //ramdomly increasing or decreasing speed

        int random;
        float speed;

        if (currentSpeed == maxspeed)
        {
            random = 1;
        }
        else if (currentSpeed == minspeed)
        {
            random = 0;
        }
        else
        {
            random = Random.Range(0, 2);
        }

        if (random == 0)
        {
            speed = currentSpeed + 0.1f;
        }
        else
        {
            speed = currentSpeed - 0.1f;
        }

        if (speed > maxspeed)
        {
            speed = maxspeed;
        }
        else if (speed < minspeed)
        {
            speed = minspeed;
        }

        currentSpeed = speed;

        speedTime = Random.Range(MinSpeedTime, MaxSpeedTime);
    }
}
