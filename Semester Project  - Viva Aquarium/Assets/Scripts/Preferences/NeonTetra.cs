using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonTetra : MonoBehaviour
{
    public static List<GameObject> NeonTetraInTankOne = new List<GameObject>();
    public static List<GameObject> NeonTetraInTankTwo = new List<GameObject>();
    public GameObject NeonTetraPrefab;
    public Fish fish;
    private void Start()
    {
        fish = this.GetComponent<Fish>();
        CheckForOtherNeonTetras();
    }

    private void Update()
    {
        if (NeonTetraInTankOne.Count >= 2)
        {
            if (fish.Happiness < 10f)
            {
                fish.Happiness += 0.00005f;
            }
            else
            {
                fish.Happiness = 10f;
            }

            //Code to change their movement so that they swim together.
        }
        else
        {
            if (fish.Happiness > 4f)
            {
                fish.Happiness -= 0.00004f;
            }
            else if (fish.Happiness <= 4f && fish.Happiness > 0f)
            {
                fish.Happiness -= 0.000002f;
            }
            else
            {
                fish.Happiness = 0f;
            }
        }
    }

    public void CheckForOtherNeonTetras()
    {
        for (int i = 0; i < GameManager.fish.Count; i++)
        {
            if (GameManager.fish[i] == NeonTetraPrefab && fish.hometankID == 1)
            {
                NeonTetraInTankOne.Add(GameManager.fish[i]);
                Debug.Log(NeonTetraInTankOne.Count);
            } 
            else if (GameManager.fish[i] == NeonTetraPrefab)
            {
                NeonTetraInTankTwo.Add(GameManager.fish[i]);
            }
        }
    }
}
