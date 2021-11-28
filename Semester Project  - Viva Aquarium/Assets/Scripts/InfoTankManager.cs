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

    public void Start()
    {
        UpgradePrice.text = "Upgrade Cost: " + UpgradeTankPrice;
        CapacityText.text = "Capacity : " + FishInTank + "/" + FishAllowed;
        FishAllowed = 8f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {
            Debug.Log("This collider should be working");
            GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            panel.GetComponent<FishPanelInfo>().targetfish = collision.gameObject;
            panel.transform.SetParent(targetpanel.transform);
            panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            panel.GetComponent<FishPanelInfo>().LoadInfo(collision.gameObject);
        }
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
}
