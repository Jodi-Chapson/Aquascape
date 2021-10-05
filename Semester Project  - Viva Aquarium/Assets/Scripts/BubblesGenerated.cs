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


    void Start()
    {
        ResetTimer = false;
       
    }


    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= 2)
        {
            bubbles ++;      //+1 each time a bubble spawns
            ResetTimer = true;
            GenerateBubble();
        }

        if (ResetTimer)
        {
            seconds = 0f;
            ResetTimer = false;
        }

       // Debug.Log(bubbles);
    }

    public void OnMouseDown()
    {
        bubbles++;
        GenerateBubble();
        seconds = 0f;
        Debug.Log("nani");
    }


    public void GenerateBubble()
    {
        Instantiate(BubblePrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
