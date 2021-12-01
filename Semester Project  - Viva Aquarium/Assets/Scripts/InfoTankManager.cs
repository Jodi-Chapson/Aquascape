using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTankManager : MonoBehaviour
{


    public Text TankLevelText;
    public Text CapacityText;
    public Text UpgradePrice;

    public float TankLevel = 1f;
    public float TankProductionModifer; //a percentage?

    public float UpgradeTankPrice = 20f; //Initial upgrade price for the tank


    public float FishInTank;
    public float FishAllowed;                  //Both these lines represent the capacity of the tank :)

    public GameObject FishFoodPrefab;
    public Transform FoodSpawnPoint;

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

    public void Start()
    {
        UpgradePrice.text = "Upgrade Cost: " + UpgradeTankPrice;
        CapacityText.text = "Capacity : " + FishInTank + "/" + FishAllowed;
        TankLevelText.text = "Tank Level : " + TankLevel;
        //FishAllowed = 8f;

        //for (int i = 0; i < GameManager.fish.Count; i++)
        //{
        //    if (GameManager.fish[i].GetComponent<Fish>().hometankID == 1)
        //    {
        //        targetpanel = GameObject.Find("Vertical Layout Group 01");
        //        Debug.Log(targetpanel);
        //        GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
        //        panel.GetComponent<FishPanelInfo>().targetfish = GameManager.fish[i].gameObject;
        //        panel.transform.SetParent(targetpanel.transform);
        //        panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
        //        panel.GetComponent<FishPanelInfo>().LoadInfo(GameManager.fish[i].gameObject);
        //    }
        //    else
        //    {
        //        targetpanel = GameObject.Find("Vertical Layout Group 02");
        //        Debug.Log(targetpanel);
        //        GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
        //        panel.GetComponent<FishPanelInfo>().targetfish = GameManager.fish[i].gameObject;
        //        panel.transform.SetParent(targetpanel.transform);
        //        panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
        //        panel.GetComponent<FishPanelInfo>().LoadInfo(GameManager.fish[i].gameObject);
        //    }
        //}
    }

    public void Update()
    {
        Timer += Time.deltaTime;

        if(Timer >= 300)
        {
            SpawnBubble();
        }
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
        }
    }

    public void SpawnBubble()
    {
        Vector3 bubblePosition = new Vector3(Random.Range(-7f,7f), Random.Range(-3f,2.5f), 0f);
        Instantiate(RandomBubble, bubblePosition, Quaternion.identity);
        BubbleSpawned = true;

        Timer = 0;
        
    }

    //    void OnMouseOver()
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            //Feed Fish
    //            GameObject.Find("Fish").GetComponent<RealTimeCounter>().Hungry = false;
    //            GameObject.Find("Fish").GetComponent<RealTimeCounter>().timer = 12;        //Reseting the Timer;


    //           // Instantiate(FishFoodPrefab, FoodSpawnPoint.position, FoodSpawnPoint.rotation);

    //            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //            Instantiate(FishFoodPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GoldFish" && TankID == 1)
        {
            collision.GetComponent<Fish>().hometankID = 1;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
        }
        else if (collision.tag == "RedTailed" && TankID == 1)
        {
            collision.GetComponent<Fish>().hometankID = 1;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
        }
        else if (collision.tag == "NeonTetra" && TankID == 1)
        {
            collision.GetComponent<Fish>().hometankID = 1;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
        }
        else
        {
            collision.GetComponent<Fish>().hometankID = 2;
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
        }
    }
}
