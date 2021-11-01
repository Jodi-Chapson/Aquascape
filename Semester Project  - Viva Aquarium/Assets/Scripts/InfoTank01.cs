using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTank01 : MonoBehaviour
{

    public Text TankLevelText;
    public Text CapacityText;
    public Text UpgradePrice;

    public float TankLevel = 1f;
    public float TankProductionModifer; //a percentage?

    public float UpgradeTankPrice = 20f; //Initial upgrade price for the tank


    public float FishInnTank;
    public float FishAllowed;                  //Both these lines represent the capacity of the tank :)

    public GameObject FishFoodPrefab;
    public Transform FoodSpawnPoint;

    public GameObject moveSpots;                 //This is for feeding the fish depending on where you click on the tank



    public void Start()
    {
        UpgradePrice.text = "Upgrade Cost: " + UpgradeTankPrice;
        FishAllowed = 8f;
        //FishInnTank = 1f;
    }

    public void Update()
    {
        
    }

    public void UpgradeTank()
    {
        if (BubbleManager.Count >= UpgradeTankPrice)  //Players can only upgrade fish tank once they only have this amount
        {
            BubblesGenerated.bubbles -= (int)UpgradeTankPrice;

            FishAllowed += 2;
            CapacityText.text = "Capacity : " + FishInnTank + "/" + FishAllowed;

            TankLevel += 1;
            TankProductionModifer++;
            TankLevelText.text = "Tank Level : " + TankLevel;


            UpgradeTankPrice = (int)(UpgradeTankPrice * 1.5f);
            UpgradePrice.text = "Upgrade Cost: " + UpgradeTankPrice;


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
