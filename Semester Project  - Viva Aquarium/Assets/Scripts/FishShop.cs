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
    public Transform Tank03SpawnPoint;
    public Transform Tank04SpawnPoint;

    public GameObject tank01fishgroup;
    public GameObject tank02fishgroup;
    public GameObject tank03fishgroup;
    public GameObject tank04fishgroup;

    public Text CapacityText;

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
        else if (manager.CurrentTankID == 2)
        {
            //targettank = manager.tanks[1];
            targettank = manager.tanks[1];
            targetspawnpoint = Tank02SpawnPoint;
            targetpanel = tank02fishgroup;
        }
        else if (manager.CurrentTankID == 3)
        {
            //targettank = manager.tanks[2];
            targettank = manager.tanks[2];
            targetspawnpoint = Tank03SpawnPoint;
            targetpanel = tank03fishgroup;
        }
        else
        {
            //targettank = manager.tanks[4];
            targettank = manager.tanks[3];
            targetspawnpoint = Tank04SpawnPoint;
            targetpanel = tank04fishgroup;
        }

            ////NB ADD THIS LATER ^^ WHEN YOUVE BROUGHT IN ALL THE TANKS

        //    if (targettank.FishInTank >= targettank.FishAllowed) //the tank is full :D
        //{
        //    return;
        //}

        if (type == 1)
        {
            fishprice = 60;
            targetfish = manager.fishtypes[0];
        }
        else if (type == 2)
        {
            fishprice = 350;
            targetfish = manager.fishtypes[1];
        }
        else if (type == 3)
        {
            fishprice = 900;
            targetfish = manager.fishtypes[2];
        }
        else
        {
            fishprice = 1500; //obviously edit this later
            targetfish = manager.fishtypes[3];
        }


        if (BubbleManager.Count >= fishprice) //Players can only buy fish once they have this amount of bubbles
        {
            //instantiates fish

            Debug.Log("nani");
            GameObject fish = Instantiate(targetfish, targetspawnpoint.position, Quaternion.identity);
            BubblesGenerated.bubbles -= fishprice;
            targettank.FishInTank += 1;
            CapacityText.text = "Capacity : " + targettank.FishInTank + "/" + targettank.FishAllowed;

            
            //instantiates associated fish panel
            //GameObject panel = Instantiate(panelprefab, Vector3.zero, Quaternion.identity);
            //panel.transform.SetParent(targetpanel.transform);
            //panel.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.3f, 1);
            //panel.GetComponent<FishPanelInfo>().LoadInfo(fish);
        }
    }

    //public void FishSelect() //This function is for the first fish
    //{
    //    if (GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank < GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed)
    //    {
    //        if (BubbleManager.Count >= 60)  //Players can only buy Fish1 once they have this amount of bubbles
    //        {
    //            Instantiate(FishType01, Tank01SpawnPoint.position, Tank01SpawnPoint.rotation);
    //            BubblesGenerated.bubbles -= 60;

    //            GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank += 1;
    //            CapacityText.text = "Capacity : " + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank + "/" + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed;
    //        }
    //    }
       
        
    //}


    //public void FishSelect02() //Function for the second fish
    //{
    //    if (GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank < GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed)
    //    {
    //        if (BubbleManager.Count >= 350)
    //        {
    //            Instantiate(FishType02, Tank02SpawnPoint.position, Tank02SpawnPoint.rotation);
    //            BubblesGenerated.bubbles -= 350;

    //            GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank += 1;
    //            CapacityText.text = "Capacity : " + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank + "/" + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed;
    //        }
    //    }
        

    //}


    //public void FishSelect03() //Function for the third fish
    //{
    //    if (GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank < GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed)
    //    {
    //        if (BubbleManager.Count >= 900)
    //        {
    //            Instantiate(FishType03, Tank03SpawnPoint.position, Tank03SpawnPoint.rotation);
    //            BubblesGenerated.bubbles -= 900;

    //            GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank += 1;
    //            CapacityText.text = "Capacity : " + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank + "/" + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed;
    //        }
    //    }
       

    //}
}
