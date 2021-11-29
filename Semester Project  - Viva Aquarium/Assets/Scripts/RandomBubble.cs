using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBubble : MonoBehaviour
{
    public float speed;
    public float LifeTime = 5f;
    public Rigidbody2D rb;

    void OnMouseOver()
    {
        Debug.Log("HEYYYYYYYYYYYYYy");
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
