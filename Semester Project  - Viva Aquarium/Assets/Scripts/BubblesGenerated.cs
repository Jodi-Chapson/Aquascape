using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubblesGenerated : MonoBehaviour
{
    float seconds = 0f;
    public static double bubbles = 0;
   

    private bool ResetTimer;

    public Transform SpawnPoint;
    public GameObject BubblePrefab;

    public int bubbleproduction;
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
        

        
        if (seconds >= 6)
        {
            bubbles += bubbleproduction;      //+1 each time a bubble spawns
            
            ResetTimer = true;
            StartCoroutine(GenerateBubble(bubbleproduction));
        }

        if (ResetTimer)
        {
            seconds = 0f;
            ResetTimer = false;
        }

        if(GameObject.Find("Dirt01").GetComponent<Dirt>().Dirty == true)
        {
            //fish need to stop producing bubbles
            bubbleproduction = 0;
            seconds = 0;
        }
       else if (GameObject.Find("Dirt01").GetComponent<Dirt>().Dirty == false)
        {
            //continue
            bubbleproduction = (int)((float)baseproduction * levelmodifier * tankmodifier * happinessmodifier * GameManager.GameSpeed);
            seconds += Time.deltaTime;
        }

    }

    
    public IEnumerator GenerateBubble(int production)
    {
        float random = Random.Range(0,1);
        
        yield return new WaitForSeconds(random);
        
        GameObject bubble = Instantiate(BubblePrefab, SpawnPoint.position, SpawnPoint.rotation);

        if (GameManager.numbers)
        {
            bubble.GetComponentInChildren<Text>().text = "+" + production;
        }
       
    }
}
