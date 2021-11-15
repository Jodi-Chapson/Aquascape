using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroy : MonoBehaviour
{
    public float LifeTime = 2f;

    void Update()
    {
        Invoke("DestroyFood", LifeTime);
    }

    void DestroyFood()
    {
        Destroy(gameObject);
    }
}
