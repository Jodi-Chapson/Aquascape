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


    public void Start()
    {
        manager = GameObject.Find("Bubble_Manager").GetComponent<GameManager>();
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
            Debug.Log("nani1");
        }
        else if (fish.GetComponent<Fish>().Species == "Red Tailed Shark")
        {
            fishsprite.GetComponent<Image>().sprite = manager.panelsprites[1];
            Debug.Log("nani2");
        }
        else if (fish.GetComponent<Fish>().Species == "Neon Tetra")
        {
            fishsprite.GetComponent<Image>().sprite = manager.panelsprites[2];
            Debug.Log("nani3");
        }
        else
        {
            fishsprite.GetComponent<Image>().sprite = manager.panelsprites[3];
            Debug.Log("nani4");
        }
        
        
        UpdateStarSprites();

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
