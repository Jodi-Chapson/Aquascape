using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeCounter : MonoBehaviour
{

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 43200; //This is 12 hours

        timer -= TimeMaster.instance.CheckDate();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if(timer <= 0)
        {
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        TimeMaster.instance.SaveDate();
        timer = 43200;
        timer -= TimeMaster.instance.CheckDate();
    }

   
}
