using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankData
{
    public float TankLevel;
    public float TankCapacity;
    public bool Unlocked;
    public float UpgradePrice;
    public float FishAllowed;
    public int TankID;
    public int DecorationInt;

     
      public TankData (InfoTankManager infotankmanager)
      {
        TankLevel = infotankmanager.TankLevel;
        TankCapacity = infotankmanager.FishInTank;
        FishAllowed = infotankmanager.FishAllowed;
        Unlocked = infotankmanager.Unlocked;
        UpgradePrice = infotankmanager.UpgradeTankPrice;
        TankID = infotankmanager.TankID;
        DecorationInt = infotankmanager.DecorationInt;
      }
}
