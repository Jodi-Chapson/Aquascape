using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockButton : MonoBehaviour
{
    public GameObject Locked;
    public GameObject Unlocked;

    public void Start()
    {
        Locked.SetActive(true);
    }

    public void OnMouseOver()
    {
        Locked.SetActive(false);
        Unlocked.SetActive(true);
    }

    public void OnMouseExit()
    {
        Locked.SetActive(true);
        Unlocked.SetActive(false);
    }
}
