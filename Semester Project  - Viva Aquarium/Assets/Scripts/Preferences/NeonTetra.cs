using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonTetra : MonoBehaviour
{
    public static int Count = 0;
    private void Start()
    {
        CheckForOtherNeonTetras();
    }

    private void Update()
    {
        if (Count >= 2)
        {
            //Insert code to make the fish more happy.
            //Code to change their movement so that they swim together.
        }
        else
        {
            //Insert the code to decrease the fish happiness.
        }
    }

    public void CheckForOtherNeonTetras()
    {
        for (int i = 0; i < GameManager.fish.Count; i++)
        {
            if (GameManager.fish[i])
            {
                if (Count == 0)
                {
                    Count++;
                    Debug.Log("Only one tetra");
                }
                else
                {
                    Count++;
                    Debug.Log(Count + " tetra");
                }
            }
        }
    }
}
