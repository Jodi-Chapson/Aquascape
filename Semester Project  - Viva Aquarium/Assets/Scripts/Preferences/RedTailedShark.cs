using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTailedShark : MonoBehaviour
{
    public GameObject RedTailedSharkPrefab;
    [SerializeField] public static List<GameObject> RedTailedFishInTankOne =  new List<GameObject>();
    [SerializeField] public static List<GameObject> RedTailedFishInTankTwo = new List<GameObject>();
    public Fish fish;

    private void Start()
    {
        fish = this.GetComponent<Fish>();
        CheckTankForOtherRedTailedSharks();
    }

    private void Update()
    {
        if (RedTailedFishInTankOne.Count >= 2 && fish.hometankID == 1)
        {
            if (fish.Happiness > 0f)
            {
                fish.Happiness -= 0.0004f;
                Debug.Log("Decresing happiness");
            }
            else
            {
                fish.Happiness = 0f;
            }
            
        }
        else
        {
            if (fish.Happiness < 10f)
            {
                fish.Happiness += 0.00005f;
            }
            else
            {
                fish.Happiness = 10f;
            }
        }

        if (RedTailedFishInTankTwo.Count >= 2 && fish.hometankID == 2)
        {
            if (fish.Happiness > 0f)
            {
                fish.Happiness -= 0.00004f;
            }
            else
            {
                fish.Happiness = 0f;
            }
        }
        else
        {
            if (fish.Happiness < 10f)
            {
                fish.Happiness += 0.00005f;
            }
            else
            {
                fish.Happiness = 10f;
            }
        }
    }

    public void CheckTankForOtherRedTailedSharks()
    {
        for (int i = 0; i < GameManager.fish.Count; i++)
        {
            if (GameManager.fish[i] == RedTailedSharkPrefab && GameManager.fish[i].GetComponent<Fish>().hometankID == 1)
            {
                RedTailedFishInTankOne.Add(GameManager.fish[i]);
            }
            else if (GameManager.fish[i] == RedTailedSharkPrefab && GameManager.fish[i].GetComponent<Fish>().hometankID == 2)
            {
                RedTailedFishInTankTwo.Add(GameManager.fish[i]);
            }
        }
    }
}
