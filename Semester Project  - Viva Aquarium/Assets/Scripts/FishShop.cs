using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShop : MonoBehaviour
{
    public GameObject FishPrefab;

    public Transform FishSpawnPoint;

    public void FishSelect()
    {
        Instantiate(FishPrefab, FishSpawnPoint.position, FishSpawnPoint.rotation);
    }
}
