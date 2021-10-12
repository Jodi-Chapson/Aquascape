using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesGenerated : MonoBehaviour
{
    float seconds = 0f;
    public static int bubbles = 0;

    private bool ResetTimer;

    public Transform SpawnPoint;
    public GameObject BubblePrefab;



    public int bubbleproduction;
    public int baseproduction;
    public InfoTank01 hometank;
    public float tankmodifier;


    void Start()
    {
        ResetTimer = false;

        hometank = GameObject.Find("Tank01").GetComponent<InfoTank01>();
        tankmodifier = hometank.TankProductionModifer;
       
    }


    void Update()
    {


        tankmodifier = hometank.TankProductionModifer;
        bubbleproduction = (int)((float)baseproduction * tankmodifier);
        seconds += Time.deltaTime;

        
        if (seconds >= 1)
        {
            bubbles += bubbleproduction;      //+1 each time a bubble spawns
            
            ResetTimer = true;
            GenerateBubble();
        }

        if (ResetTimer)
        {
            seconds = 0f;
            ResetTimer = false;
        }

    }

    public void GenerateBubble()
    {
        Instantiate(BubblePrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
