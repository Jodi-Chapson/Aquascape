using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeCounter : MonoBehaviour
{

    public float timer;

    public bool Hungry;


    void Start()
    {
        timer = 12; //43200; //This is 12 hours

        timer -= TimeMaster.instance.CheckDate();

        Hungry = false;
    }


    void Update()
    {
        timer -= Time.deltaTime;
       // Debug.Log(timer);

        if(timer <= 0)
        {
            ResetTimer();
            Hungry = true;
        }
    }

    void ResetTimer()
    {
        TimeMaster.instance.SaveDate();
        timer = 12; //43200;
        timer -= TimeMaster.instance.CheckDate();

    }

   
}
