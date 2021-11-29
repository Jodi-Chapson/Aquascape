using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTailedShark : MonoBehaviour
{
    public GameObject RedTailedSharkPrefab;
    [SerializeField] public static int Count = 0; //This value will have to decrease when one is sold.

    private void Start()
    {
        CheckTankForOtherRedTailedSharks();
    }

    private void Update()
    {
        if (Count >= 1)
        {
            //Insert code to decrease the fishes happiness. This can be done anywhere as long as we check if the count variable is greater or equal to 1.
        }
    }

    public void CheckTankForOtherRedTailedSharks()
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
                    Debug.Log("Multiple red tailed sharks");
                }
            }
        }
    }
}
