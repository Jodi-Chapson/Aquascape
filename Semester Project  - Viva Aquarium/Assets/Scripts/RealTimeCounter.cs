using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTimeCounter : MonoBehaviour
{

    public float timer;

    public bool Hungry;

    void Start()
    {
        timer = 86400;          //This is 24 hours

        timer -= TimeMaster.instance.CheckDate();

        Hungry = false;
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 43200)             //This is 12 hours    
        {
            Hungry = true;       
        }
        else
        {
            Hungry = false;
        }

        if(timer <= 0)                  //If Fish gets fed, reset timer
        {
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        TimeMaster.instance.SaveDate();
        timer = 86400;
        timer -= TimeMaster.instance.CheckDate();
    }

   
}
