using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankData
{
    public float TankLevel;
    public float TankCapacity;
    public bool Unlocked;

     
      public TankData (InfoTankManager infotankmanager)
      {
        TankLevel = infotankmanager.TankLevel;
        TankCapacity = infotankmanager.FishInTank;
        Unlocked = infotankmanager.Unlocked;
      }
}
