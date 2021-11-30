using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishData
{
    public int Level;
    public float Happiness;
    public string Species = "";
    public int HomeTankID;

    /* 
     * This will save the fishes data so that it can be saved into a file and then loaded when needed.
     */

     public FishData (Fish fish) 
     {
        Level = fish.Level;
        Happiness = fish.Happiness;
        Species = fish.Species;
        HomeTankID = fish.hometankID;
      }

}
