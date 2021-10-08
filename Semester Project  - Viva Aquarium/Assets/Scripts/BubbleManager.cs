using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{

    public static int Count = 0;

    public Text KeepCount;

    void Update()
    {
        Count = BubblesGenerated.bubbles;

        //Debug.Log(Count +"Bubbles");

        KeepCount.text = Count + "";
    }
}

