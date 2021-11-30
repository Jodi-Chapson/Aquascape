using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBubble : MonoBehaviour
{

    public float LifeTime;
    
    void Start()
    {
        Invoke("Destroy", LifeTime);  //Destroy bubble after specific amount of seconds has passed
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (this.transform.position.y >= 2f)
        {
            Destroy();
        }
    }

   
}
