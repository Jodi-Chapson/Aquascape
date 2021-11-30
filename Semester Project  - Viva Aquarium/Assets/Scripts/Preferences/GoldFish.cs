using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFish : MonoBehaviour
{
    public Fish fish;
    private void Start()
    {
        fish = this.GetComponent<Fish>();
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
                fish.Happiness -= 0.00004f;
            }
            else
            {
                fish.Happiness = 0f;
            }
        }
    }
}
