using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTank01 : MonoBehaviour
{

    public Text TankLevelText;

    public float TankLevel = 1f;

    public float UpgradeTankPrice = 20f; //Initial upgrade price for the tank

    


    public void UpgradeTank()
    {
        if (BubbleManager.Count >= UpgradeTankPrice)  //Players can only upgrade fish tank once they only have this amount
        {
            BubblesGenerated.bubbles -= (int) UpgradeTankPrice;


            TankLevel += 1;
            TankLevelText.text = "Tank Level : " + TankLevel;


            UpgradeTankPrice += 20; //The next upgrade will cost 20 bubbles more
        }

    }
}
