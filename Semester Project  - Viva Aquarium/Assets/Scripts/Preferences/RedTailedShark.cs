using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTailedShark : MonoBehaviour
{
    public GameObject RedTailedSharkPrefab;
    [SerializeField] public static int Count = 0;
    [SerializeField] public static bool isRedTailedFish;

    private void Start()
    {
        isRedTailedFish = false;
        CheckTankForOtherRedTailedSharks();
    }

    private void CheckTankForOtherRedTailedSharks()
    {
        Debug.Log(GameManager.fish.Count);

        for (int i = 0; i < GameManager.fish.Count; i++)
        {
            if (GameManager.fish[i] == RedTailedSharkPrefab)
            {
                if (Count == 0)
                {
                    Count++;
                    Debug.Log("one red tailed shark is in there");
                }
                else
                {
                    Count++;
                    isRedTailedFish = true;
                    //code to decrease happiness.
                    Debug.Log("Multiple red tailed sharks");
                }
            }
        }
    }
}
