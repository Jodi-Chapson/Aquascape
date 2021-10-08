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
    

    public float FishInTank = 1f;       
    public float FishAllowed = 8f;                  //Both these lines represent the capacity of the tank :)


    public void Start()
    {
        UpgradePrice.text = "Upgrade Cost: " + UpgradeTankPrice;
    }

    public void UpgradeTank()
    {
        if (BubbleManager.Count >= UpgradeTankPrice)  //Players can only upgrade fish tank once they only have this amount
        {
            BubblesGenerated.bubbles -= (int) UpgradeTankPrice;

            FishAllowed += 2;
            CapacityText.text = "Capacity : " + FishInTank + "/" + FishAllowed;

            TankLevel += 1;
            TankProductionModifer ++;
            TankLevelText.text = "Tank Level : " + TankLevel;


            UpgradeTankPrice = (int)(UpgradeTankPrice * 1.5f);
            UpgradePrice.text = "Upgrade Cost: " + UpgradeTankPrice;

           
        }

   

    }
}
