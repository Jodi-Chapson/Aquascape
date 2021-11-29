using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFish : MonoBehaviour
{
    public static int NumOfFish = 0; //Value must decrease when a fish is sold.
    private void Start()
    {
        if (GameManager.fish.Count >= 2)
        {
            NumOfFish = GameManager.fish.Count;
        }
    }
    private void Update()
    {
        if (NumOfFish >= 2)
        {
            //Insert code to increase the fish happiness.
        }
        else
        {
            //Insert code to decrease the fish happiness 
        }
    }
}
