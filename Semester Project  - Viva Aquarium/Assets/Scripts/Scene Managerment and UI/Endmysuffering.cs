using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endmysuffering : MonoBehaviour
{
    // Start is called before the first frame update

    public Scrollbar scrollbar;
    void Start()
    {
        
    }

    public void MoveUP()
    {
        scrollbar.value = 1;

        Debug.Log("nani");
    }
}
