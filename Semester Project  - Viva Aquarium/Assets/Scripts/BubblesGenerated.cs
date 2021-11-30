using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesGenerated : MonoBehaviour
{
    float seconds = 0f;
    public static double bubbles = 0;

    private bool ResetTimer;

    public Transform SpawnPoint;
    public GameObject BubblePrefab;

    public float bubbleproduction;
    public int baseproduction;
    public int level;
    public int levelmodifier = 1;
    public float happinessmodifier;
    public int hometankID;
    public InfoTankManager hometank;
    public float tankmodifier;

    public Fish fish;

    void Start()
    {
        ResetTimer = false;
        fish = this.GetComponent<Fish>();
        hometank = GameObject.Find("Tank01").GetComponent<InfoTankManager>();
        tankmodifier = hometank.TankProductionModifer;
        
       
    }


    void Update()
    {
        happinessmodifier = fish.Happiness / 10;
        tankmodifier = hometank.TankProductionModifer;
        bubbleproduction = baseproduction + ((float)baseproduction * levelmodifier * tankmodifier * happinessmodifier);
        seconds += Time.deltaTime;

        
        if (seconds >= 3)
        {
            bubbles += bubbleproduction;      //+1 each time a bubble spawns
            
            ResetTimer = true;
            StartCoroutine(GenerateBubble());
        }

        if (ResetTimer)
        {
            seconds = 0f;
            ResetTimer = false;
        }

    }

    
    public IEnumerator GenerateBubble()
    {
        float random = Random.Range(0,1);
        
        yield return new WaitForSeconds(random);
        
        Instantiate(BubblePrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
