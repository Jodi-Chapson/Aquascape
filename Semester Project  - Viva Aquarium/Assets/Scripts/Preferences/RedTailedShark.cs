using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTailedShark : MonoBehaviour
{
    public GameObject RedTailedSharkPrefab;
    [SerializeField] public static List<GameObject> RedTailedFishInTank =  new List<GameObject>(); 
    public Fish fish;

    private void Start()
    {
        fish = this.GetComponent<Fish>();
        CheckTankForOtherRedTailedSharks();
    }

    private void Update()
    {
        if (RedTailedFishInTank.Count >= 2)
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
        Debug.Log(GameManager.fish.Count);

        for (int i = 0; i < GameManager.fish.Count; i++)
        {
            if (GameManager.fish[i] == RedTailedSharkPrefab)
            {
                RedTailedFishInTank.Add(this.gameObject);
            }
        }
    }
}
