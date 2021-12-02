using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    public Vector3 movement;
    public float modifier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += movement * Time.deltaTime * modifier;
    }
}
