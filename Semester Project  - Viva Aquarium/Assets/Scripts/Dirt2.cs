using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dirt2 : MonoBehaviour
{
    public Animator Anim;

    public float DirtTimer;
    public bool Dirty;

    private Image dirtImage;

    void Start()
    {
        DirtTimer = 600;          //This is 10 minutes
        Dirty = false;

        dirtImage = GetComponent<Image>();
    }

    void Update()
    {
        if (GameObject.Find("Tank02").GetComponent<InfoTankManager>().Unlocked == false)
        {
            DirtTimer = 600;
        }
        else
        {
            DirtTimer -= Time.deltaTime;
        }

        if (DirtTimer <= 0)              //Tank is dirty and has to be filled with dirt
        {
            Dirty = true;
            StartCoroutine(StartAnimation());
        }
        else
        {
            Dirty = false;
        }



    }

    void ResetTimer()
    {
        DirtTimer = 600;
    }


    IEnumerator StartAnimation()
    {
        Anim.SetTrigger("Dirt");
        yield return new WaitForSeconds(10f);
    }

    public void CleanTank()                         //This goes on the button in the Tank UI
    {
        ResetTimer();
        Anim.SetTrigger("Clean");

    }

}

