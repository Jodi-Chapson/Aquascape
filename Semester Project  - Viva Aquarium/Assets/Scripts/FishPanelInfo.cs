using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishPanelInfo : MonoBehaviour
{
    public GameObject targetfish;
    public GameObject onestar, twostar, threestar, fourstar, fivestar;
    public Image fishsprite;
    public Text UpgradePrice;
    public GameObject Upgradebutton;
    public int UpgradeFishPrice;
    public int currentlevel;



    public void LoadInfo(GameObject fish)
    {

        targetfish = fish;
        currentlevel = fish.GetComponent<BubblesGenerated>().level;
        
        
        UpdateStarSprites();

    }

    public void Start()
    {
        UpgradePrice.text = "Price: " + UpgradeFishPrice;
    }

    public void Upgrade()
    {
        if (currentlevel >= 5)
        {
            return;
        }
        
        if (BubbleManager.Count >= UpgradeFishPrice)
        {
            BubblesGenerated.bubbles -= (int)UpgradeFishPrice;

            UpgradeFishPrice = (int)(UpgradeFishPrice * 1.5f);
            
            UpgradePrice.text = "Price: " + UpgradeFishPrice;

            targetfish.GetComponent<BubblesGenerated>().levelmodifier += 1;
            targetfish.GetComponent<BubblesGenerated>().level += 1;
            currentlevel = targetfish.GetComponent<BubblesGenerated>().level;

            UpdateStarSprites();
            
        }

        if (currentlevel == 5)
        {
            UpgradePrice.gameObject.SetActive(false);
            Upgradebutton.SetActive(false);
        }
    }

    public void UpdateStarSprites()
    {
        if (currentlevel == 0)
        {
            Debug.Log("nani");
        }
        else if (currentlevel == 1)
        {
            onestar.SetActive(true);
        }
        else if (currentlevel == 2)
        {
            twostar.SetActive(true);
        }
        else if (currentlevel == 3)
        {
            threestar.SetActive(true);
        }
        else if (currentlevel == 4)
        {
            fourstar.SetActive(true);
        }
        else
        {
            fivestar.SetActive(true);
        }

    }

    public void Update()
    {
        currentlevel = targetfish.GetComponent<BubblesGenerated>().level;
    }
}
