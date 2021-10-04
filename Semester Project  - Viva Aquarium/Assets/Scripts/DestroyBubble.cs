using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBubble : MonoBehaviour
{

    public float LifeTime = 5f;
    
    void Start()
    {
        Invoke("Destroy", LifeTime);  //Destroy bubble after specific amount of seconds has passed
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

   
}
