using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMaster : MonoBehaviour
{

    DateTime currentDate;
    DateTime oldDate;

    public string saveLocation;
    public static TimeMaster instance;

   void Awake()
    {
        instance = this;

        saveLocation = "LastSaveddate1";
    }

    public float CheckDate()
    {
        //stores current time when game starts 

        currentDate = System.DateTime.Now;

        string tempString = PlayerPrefs.GetString(saveLocation, "1");

        //Grab old time from the player prefs as a long 

        long tempLong = Convert.ToInt64(tempString);

        //comnvert the old time binary to a DateTime variable 

        DateTime oldDate = DateTime.FromBinary(tempLong);
        print("Old Date : " + oldDate);

        //use the subtract method and store the result as a timespan

        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);

        return (float)difference.TotalSeconds;
    }

    public void SaveDate()
    {
        //Save the current system time 

        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());

        print("Saving this date to player prefs: " + System.DateTime.Now);
    }
}
