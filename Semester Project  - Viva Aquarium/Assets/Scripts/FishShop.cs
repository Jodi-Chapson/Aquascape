using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShop : MonoBehaviour
{
    public GameObject FishPrefab;

    public Transform FishSpawnPoint;

    public void FishSelect()
    {
        if (BubbleManager.Count >= 5)  //Players can only buy Fish1 once they have this amount of bubbles
        {
            Instantiate(FishPrefab, FishSpawnPoint.position, FishSpawnPoint.rotation);
            BubblesGenerated.bubbles -= 5; 
        }
        
    }
}
