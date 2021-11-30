using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFish : MonoBehaviour
{
    public Fish fish;
    public BubblesGenerated bubblesgenerated;
    private void Start()
    {
        fish = this.GetComponent<Fish>();
        bubblesgenerated = this.GetComponent<BubblesGenerated>();
    }
    private void Update()
    {
        if (GameManager.fish.Count >= 3)
        {
            if (fish.Happiness < 10f)
            {
                fish.Happiness += 0.00005f;
            }
            else
            {
                fish.Happiness = 10f;
            }
        }
        else
        {
            if (fish.Happiness > 0f)
            {
                fish.Happiness -= 0.00000001f;
            }
            else
            {
                fish.Happiness = 0f;
            }
        }
    }
}
