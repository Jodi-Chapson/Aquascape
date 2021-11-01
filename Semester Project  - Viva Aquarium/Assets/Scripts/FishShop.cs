using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishShop : MonoBehaviour
{
    public GameObject FishPrefab;
    public Transform FishSpawnPoint;

    public GameObject FishPrefab02;
    public Transform FishSpawnPoint02;

    public GameObject FishPrefab03;
    public Transform FishSpawnPoint03;

    public Text CapacityText;


    public void FishSelect() //This function is for the first fish
    {
        if (GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank < GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed)
        {
            if (BubbleManager.Count >= 60)  //Players can only buy Fish1 once they have this amount of bubbles
            {
                Instantiate(FishPrefab, FishSpawnPoint.position, FishSpawnPoint.rotation);
                BubblesGenerated.bubbles -= 60;

                GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank += 1;
                CapacityText.text = "Capacity : " + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank + "/" + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed;
            }
        }
       
        
    }


    public void FishSelect02() //Function for the second fish
    {
        if (GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank < GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed)
        {
            if (BubbleManager.Count >= 350)
            {
                Instantiate(FishPrefab02, FishSpawnPoint02.position, FishSpawnPoint02.rotation);
                BubblesGenerated.bubbles -= 350;

                GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank += 1;
                CapacityText.text = "Capacity : " + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank + "/" + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed;
            }
        }
        

    }


    public void FishSelect03() //Function for the third fish
    {
        if (GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank < GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed)
        {
            if (BubbleManager.Count >= 900)
            {
                Instantiate(FishPrefab03, FishSpawnPoint03.position, FishSpawnPoint03.rotation);
                BubblesGenerated.bubbles -= 900;

                GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank += 1;
                CapacityText.text = "Capacity : " + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishInnTank + "/" + GameObject.Find("Tank01").GetComponent<InfoTank01>().FishAllowed;
            }
        }
       

    }
}
