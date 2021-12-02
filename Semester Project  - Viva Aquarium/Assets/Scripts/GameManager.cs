using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InfoTankManager[] tanks = new InfoTankManager[4]; //reference to all the relevant tanks, for assigning home tanks
    public GameObject[] fishtypes = new GameObject[4]; //reference to all the relevant fish prefabs
    public Sprite[] panelsprites = new Sprite[4]; // reference for all panel sprites
    public Sprite[] tankthemes = new Sprite[3]; // reference for all tank designs sprites
    public SpriteRenderer tank1, tank2;

    public static List<GameObject> fish = new List<GameObject>();
    public int CurrentTankID;

    public void ChangeThemeToInt (int themeID)
    {
        if (CurrentTankID == 1)
        {
            if (themeID == 0)
            {
                tank1.sprite = tankthemes[0];
            }
            else if (themeID == 1)
            {
                tank1.sprite = tankthemes[1];
            }
            else if (themeID == 2)
            {
                tank1.sprite = tankthemes[2];
            }



        }
        else
        {
            if (themeID == 0)
            {
                tank2.sprite = tankthemes[0];
            }
            else if (themeID == 1)
            {
                tank2.sprite = tankthemes[1];
            }
            else if (themeID == 2)
            {
                tank2.sprite = tankthemes[2];
            }

        }
    }

}
