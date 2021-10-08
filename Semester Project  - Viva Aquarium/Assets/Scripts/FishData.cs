using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishData
{
    public int Level;
    public float Happiness;
    public string Species = "";

    /* 
     * This will save the fishes data so that it can be saved into a file and then loaded when needed.
     */

    /* public PlayerData (Fish fish) - Constructor to make initialisation easier -
     * {
     *    Level = fish.level;
     *    Happiness = fish.happiness;
     *    Species = fish.species;
     * }
     */
}
