using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonTetra : MonoBehaviour
{
    public static List<GameObject> NeonTetraInTankOne = new List<GameObject>();
    public static List<GameObject> NeonTetraInTankTwo = new List<GameObject>();
    public GameObject NeonTetraPrefab;
    public Fish fish;

    private void Awake()
    {
        //this.gameObject.GetComponent<Fish>().SwimmingArea = GameObject.Find("Neon Tetra Swimming Area " + this.gameObject.GetComponent<Fish>().hometankID).GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        fish = this.GetComponent<Fish>();
        CheckForOtherNeonTetras();

    }

    private void Update()
    {
        //this.gameObject.GetComponent<Fish>().SwimmingArea = GameObject.Find("Neon Tetra Swimming Area " + this.gameObject.GetComponent<Fish>().hometankID).GetComponent<BoxCollider2D>();
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
