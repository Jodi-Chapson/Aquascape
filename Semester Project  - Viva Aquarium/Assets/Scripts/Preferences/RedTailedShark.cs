using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTailedShark : MonoBehaviour
{
    public GameObject RedTailedSharkPrefab;
    public int Count = 0;
    
    private void Update()
    {
        CheckTankForOtherRedTailedSharks();
    }

    private void CheckTankForOtherRedTailedSharks()
    {
        for (int i = 0; i < GameManager.fish.Count; i++)
        {
            if (GameManager.fish[i] == RedTailedSharkPrefab)
            {
                if (Count <= 1)
                {
                    Count++;
                    Debug.Log("one red tailed shark is in there");
                }
                else if (Count > 1)
                {
                    Count++;
                    //code to decrease happiness.
                    Debug.Log("Multiple red tailed sharks");
                }
            }
        }
    }
}
