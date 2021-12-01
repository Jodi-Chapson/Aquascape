using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishPanelInfo : MonoBehaviour
{
    public GameObject targetfish;
    public GameManager manager;
    public GameObject onestar, twostar, threestar, fourstar, fivestar;
    public GameObject fishsprite;
    public Text UpgradePrice, FishSpecies;
    public GameObject Upgradebutton;
    public int UpgradeFishPrice;
    public int currentlevel;
    public GameObject FishID;

    public void Start()
    {
        manager = GameObject.Find("Bubble_Manager").GetComponent<GameManager>();
        UpgradeFishPrice = FishID.GetComponent<Fish>().UpgradePrice;
        UpgradePrice.text = "Price: " + UpgradeFishPrice;
    }

    public void LoadInfo(GameObject fish)
    {
        manager = GameObject.Find("Bubble_Manager").GetComponent<GameManager>();
        targetfish = fish;
        currentlevel = fish.GetComponent<BubblesGenerated>().level;
        FishSpecies.text = fish.GetComponent<Fish>().Species.ToString();

        if (fish.GetComponent<Fish>().Species == "Gold Fish")
        {
            fishsprite.GetComponent<Image>().sprite = manager.panelsprites[0];
            
        }
        else if (fish.GetComponent<Fish>().Species == "Red Tailed Shark")
        {
            fishsprite.GetComponent<Image>().sprite = manager.panelsprites[1];
            
        }
        else if (fish.GetComponent<Fish>().Species == "Neon Tetra")
        {
            fishsprite.GetComponent<Image>().sprite = manager.panelsprites[2];
            
        }
        else
        {
            fishsprite.GetComponent<Image>().sprite = manager.panelsprites[3];
            
        }    
        
        UpdateStarSprites(fish.GetComponent<Fish>());
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

            targetfish.GetComponent<Fish>().Level += 1;
            targetfish.GetComponent<BubblesGenerated>().levelmodifier += 1;
            targetfish.GetComponent<BubblesGenerated>().level += 1;
            targetfish.GetComponent<Fish>().UpgradePrice = UpgradeFishPrice;
            currentlevel = targetfish.GetComponent<BubblesGenerated>().level;

            UpdateStarSprites(targetfish.GetComponent<Fish>());
            
        }

        if (currentlevel == 5)
        {
            UpgradePrice.gameObject.SetActive(false);
            Upgradebutton.SetActive(false);
        }
    }

    public void UpdateStarSprites(Fish fish)
    {
        if (fish.Level == 0)
        {
            
        }
        else if (fish.Level == 1)
        {
            onestar.SetActive(true);
        }
        else if (fish.Level == 2)
        {
            twostar.SetActive(true);
        }
        else if (fish.Level == 3)
        {
            threestar.SetActive(true);
        }
        else if (fish.Level == 4)
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
