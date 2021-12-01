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
        //this.gameObject.GetComponent<Fish>().SwimmingArea = GameObject.Find("Red Tailed Shark Swimming Area " + this.gameObject.GetComponent<Fish>().hometankID).GetComponent<BoxCollider2D>();
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
