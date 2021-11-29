using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBubble : MonoBehaviour
{
    public float speed;
    public float LifeTime = 5f;
    public Rigidbody2D rb;

  //  public GameObject PopPrefab;
   // public Transform PopPosition;

    void OnMouseDown()
    {
        // Instantiate(PopPrefab, PopPosition.position, Quaternion.identity);
        DestroyBubble();
        BubblesGenerated.bubbles += 250f;
    }

    void Start()
    {
        rb.velocity = transform.up * speed;
        Invoke("DestroyBubble", LifeTime);
    }

    void DestroyBubble()
    {
        Destroy(gameObject);
    }

}
