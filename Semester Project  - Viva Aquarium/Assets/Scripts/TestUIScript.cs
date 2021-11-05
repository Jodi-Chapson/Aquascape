using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIScript : MonoBehaviour
{
    public GameObject prefab;

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("p"))
        {
            GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            go.transform.SetParent(GameObject.Find("Fish Group").transform);
            
            
        }
    }
    
}
