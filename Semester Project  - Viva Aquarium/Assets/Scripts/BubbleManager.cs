using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{

    public static double Count = 0;

    public Text KeepCount;

    void Update()
    {

        Count = BubblesGenerated.bubbles;
        KeepCount.text = Count.ToString("0") + "";

        if (Count >= 1000)
        {
            if(Count>= 1000000)
            {
                KeepCount.text = (Count / 1000000f).ToString("F2") + " M";
            }
            else
            {
                KeepCount.text = (Count / 1000f).ToString("F2") + " K";
            }
        }


      if (Input.GetKeyDown("h"))
        {
            
            BubblesGenerated.bubbles += 1000f;
        }

    }
}

