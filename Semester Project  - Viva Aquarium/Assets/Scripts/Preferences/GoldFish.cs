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
}
