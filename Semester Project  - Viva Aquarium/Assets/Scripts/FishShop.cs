using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishShop : MonoBehaviour
{
    public GameManager manager;
    public GameObject panelprefab;
    
    public Transform Tank01SpawnPoint;
    public Transform Tank02SpawnPoint;

    public GameObject tank01fishgroup;
    public GameObject tank02fishgroup;
    public GameObject tank03fishgroup;
    public GameObject tank04fishgroup;

    public Text CapacityText;

    public AudioSource SoundEffect;

    public void Start()
    {
        manager = GameObject.Find("Bubble_Manager").GetComponent<GameManager>();   
    }

    public void BuyFish(int type)
    {
        InfoTankManager targettank;
        Transform targetspawnpoint;
        GameObject targetpanel;
        GameObject targetfish;
        int fishprice;

        if (manager.CurrentTankID == 1) //checks which tank the player is currently on, and then assigns the appropriate tank
        {
            targettank = manager.tanks[0];
            targetspawnpoint = Tank01SpawnPoint;
            targetpanel = tank01fishgroup;
        }
        else
        {
            //targettank = manager.tanks[1];
            targettank = manager.tanks[1];
            targetspawnpoint = Tank02SpawnPoint;
            targetpanel = tank02fishgroup;
        }
        

         

          if (targettank.FishInTank >= targettank.FishAllowed) //the tank is full :D
        {
            return;
        }

        if (type == 1)
        {
            fishprice = 60;
            targetfish = manager.fishtypes[0];
            SoundEffect.Play();
        }
        else if (type == 2)
        {
            fishprice = 350;
            targetfish = manager.fishtypes[1];
            SoundEffect.Play();
        }
        else if (type == 3)
        {
            fishprice = 900;
            targetfish = manager.fishtypes[2];
            SoundEffect.Play();
        }
        else
        {
            fishprice = 1500; //obviously edit this later
            targetfish = manager.fishtypes[3];
            SoundEffect.Play();
        }


        if (BubbleManager.Count >= fishprice) //Players can only buy fish once they have this amount of bubbles
        {
            //instantiates fish

            
            GameObject fish = Instantiate(targetfish, targetspawnpoint.position, Quaternion.identity);

            if (type == 4)
            {
                manager.RandomizeBetta(fish);
            }

            BubblesGenerated.bubbles -= fishprice;
            targettank.FishInTank += 1;
            targettank.CapacityText.text = "Capacity : " + targettank.FishInTank + "/" + targettank.FishAllowed;
            CapacityText.text = "Capacity : " + targettank.FishInTank + "/" + targettank.FishAllowed;

            
            //instantiates associated fish panel
            //GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            //panel.transform.SetParent(targetpanel.transform);
            //panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            //panel.GetComponent<FishPanelInfo>().LoadInfo(fish);
        }
    }

   
}
