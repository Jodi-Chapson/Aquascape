using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTankManager : MonoBehaviour
{
    public GameManager manager;

    public Text TankLevelText;
    public Text CapacityText;
    public Text UpgradePrice;
    public GameObject UpgradeButton;
    public GameObject Decor2_button, Decor3_button, Decor4_button;

    public float TankLevel = 1f;
    public float TankProductionModifer; //a percentage?

    public float UpgradeTankPrice; //Initial upgrade price for the tank


    public float FishInTank;
    public float FishAllowed;                  //Both these lines represent the capacity of the tank :)

    public GameObject FishFoodPrefab;

    public GameObject moveSpots;                 //This is for feeding the fish depending on where you click on the tank

    public bool Unlocked; //Set in the unity project

    public GameObject panelprefab;
    public GameObject targetpanel;

    public GameObject RandomBubble;
    public float Timer;
    public bool BubbleSpawned = false;

    public GameObject PopPrefab;
    public Transform PopPosition;

    public int TankID;
    public bool MouseOverTank;

    public int DecorationInt;

    public void Start()
    {
        
        UpgradePrice.text = "Upgrade Cost: " + UpgradeTankPrice;
        CapacityText.text = "Capacity : " + FishInTank + "/" + FishAllowed;
        TankLevelText.text = "Tank Level : " + TankLevel;
        //FishAllowed = 8f;
    }

    public void Update()
    {
        Timer += Time.deltaTime;

        if(Timer >= 300)
        {
            SpawnBubble();
        }

      /*  if (Input.GetMouseButtonDown(0) && MouseOverTank)
        {
            //Feed Fish and increase happiness levels
            GameObject.Find("Fish").GetComponent<RealTimeCounter>().Hungry = false;
            GameObject.Find("Fish").GetComponent<RealTimeCounter>().timer = 12;        //Reseting the Timer;


            // Instantiate(FishFoodPrefab, FoodSpawnPoint.position, FoodSpawnPoint.rotation);

            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(FishFoodPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
        }*/


    }

    public void UpgradeTank()
    {
        if (BubbleManager.Count >= UpgradeTankPrice)  //Players can only upgrade fish tank once they only have this amount
        {
                BubblesGenerated.bubbles -= (int)UpgradeTankPrice;

                FishAllowed += 2;
                CapacityText.text = "Capacity : " + FishInTank + "/" + FishAllowed;

                TankLevel += 1;
                TankProductionModifer++;
                TankLevelText.text = "Tank Level : " + TankLevel;


                UpgradeTankPrice = (int)(UpgradeTankPrice * 1.5f);
                UpgradePrice.text = "Upgrade Cost: " + UpgradeTankPrice;

            if (TankLevel == 1)
            {
                Decor2_button.SetActive(true);
            }
            else if (TankLevel == 2)
            {
                Decor3_button.SetActive(true);
            }
            
            if (TankLevel == 3)
            {
                UpgradeButton.SetActive(false);
                UpgradePrice.gameObject.SetActive(false);
                TankLevelText.text = "Tank Level : 3 (MAX)";
                Decor4_button.SetActive(true);
            }
        }
    }

    public void SpawnBubble()
    {
        Vector3 bubblePosition = new Vector3(Random.Range(-7f,7f), Random.Range(-3f,2.5f), 0f);
        Instantiate(RandomBubble, bubblePosition, Quaternion.identity);
        BubbleSpawned = true;

        Timer = 0;   
    }

 /*  void OnMouseOver()
    { 
       MouseOverTank = true;     
    }

    void OnMouseExit()
    {
        MouseOverTank = false;
    }*/
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GoldFish" && TankID == 1)
        {
            collision.GetComponent<Fish>().hometankID = 1;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            collision.GetComponent<Fish>().SwimmingArea = GameObject.Find("Gold Fish Swimming Area 1").GetComponent<BoxCollider2D>();
            collision.GetComponent<Fish>().hasSwimmingArea = true;
            collision.GetComponent<BubblesGenerated>().tankmodifier = TankLevel + 1;
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
            panel.GetComponent<FishPanelInfo>().FishID = collision.gameObject;
        }
        else if (collision.tag == "RedTailed" && TankID == 1)
        {
            collision.GetComponent<Fish>().hometankID = 1;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            collision.GetComponent<Fish>().SwimmingArea = GameObject.Find("Red Tailed Shark Swimming Area 1").GetComponent<BoxCollider2D>();
            collision.GetComponent<Fish>().hasSwimmingArea = true;
            collision.GetComponent<BubblesGenerated>().tankmodifier = TankLevel + 1;
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
            panel.GetComponent<FishPanelInfo>().FishID = collision.gameObject;
        }
        else if (collision.tag == "NeonTetra" && TankID == 1)
        {
            collision.GetComponent<Fish>().hometankID = 1;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            collision.GetComponent<Fish>().SwimmingArea = GameObject.Find("Neon Tetra Swimming Area 1").GetComponent<BoxCollider2D>();
            collision.GetComponent<Fish>().hasSwimmingArea = true;
            collision.GetComponent<BubblesGenerated>().tankmodifier = TankLevel + 1;
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
            panel.GetComponent<FishPanelInfo>().FishID = collision.gameObject;
        }
        else if (collision.tag == "Betta" && TankID == 1)
        {
            collision.GetComponent<Fish>().hometankID = 1;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            collision.GetComponent<Fish>().SwimmingArea = GameObject.Find("Gold Fish Swimming Area 1").GetComponent<BoxCollider2D>();
            collision.GetComponent<Fish>().hasSwimmingArea = true;
            collision.GetComponent<BubblesGenerated>().tankmodifier = TankLevel + 1;
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
            panel.GetComponent<FishPanelInfo>().FishID = collision.gameObject;
        }
        else
        {
            collision.GetComponent<Fish>().hometankID = 2;

            if (collision.tag == "GoldFish")
            {
                collision.GetComponent<Fish>().SwimmingArea = GameObject.Find("Gold Fish Swimming Area 2").GetComponent<BoxCollider2D>();
                collision.GetComponent<Fish>().hasSwimmingArea = true;
            }
            else if (collision.tag == "RedTailed")
            {
                collision.GetComponent<Fish>().SwimmingArea = GameObject.Find("Red Tailed Shark Swimming Area 2").GetComponent<BoxCollider2D>();
                collision.GetComponent<Fish>().hasSwimmingArea = true;
            }
            else if (collision.tag == "NeonTetra")
            {
                collision.GetComponent<Fish>().SwimmingArea = GameObject.Find("Neon Tetra Swimming Area 2").GetComponent<BoxCollider2D>();
                collision.GetComponent<Fish>().hasSwimmingArea = true;
            }
            else if (collision.tag == "Betta")
            {
                collision.GetComponent<Fish>().SwimmingArea = GameObject.Find("Gold Fish Swimming Area 2").GetComponent<BoxCollider2D>();
                collision.GetComponent<Fish>().hasSwimmingArea = true;
            }
            collision.GetComponent<BubblesGenerated>().tankmodifier = TankLevel + 1;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
            panel.GetComponent<FishPanelInfo>().FishID = collision.gameObject;
        }
    }
}
