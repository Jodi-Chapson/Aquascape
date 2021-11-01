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



    public int bubbleproduction;
    public int baseproduction;
    public int levelmodifier = 1;
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
        bubbleproduction = (int)((float)baseproduction * levelmodifier * tankmodifier);
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
