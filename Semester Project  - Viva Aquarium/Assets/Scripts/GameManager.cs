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
    public Sprite block, tick_block;
    public GameObject tank1decor1, tank1decor2, tank1decor3;
    public GameObject tank2decor1, tank2decor2, tank2decor3;

    public static List<GameObject> fish = new List<GameObject>();
    public int CurrentTankID;

    public static int GameSpeed;
    public GameObject circle;
    public GameObject x1, x2, x3;

    public void ChangeThemeToInt (int themeID)
    {
        if (CurrentTankID == 1)
        {
            if (themeID == 0)
            {
                tank1.sprite = tankthemes[0];

                tank1decor1.GetComponent<Image>().sprite = tick_block;
                tank1decor2.GetComponent<Image>().sprite = block;
                tank1decor3.GetComponent<Image>().sprite = block;

            }
            else if (themeID == 1)
            {
                tank1.sprite = tankthemes[1];

                tank1decor1.GetComponent<Image>().sprite = block;
                tank1decor2.GetComponent<Image>().sprite = tick_block;
                tank1decor3.GetComponent<Image>().sprite = block;
            }
            else if (themeID == 2)
            {
                tank1.sprite = tankthemes[2];

                tank1decor1.GetComponent<Image>().sprite = block;
                tank1decor2.GetComponent<Image>().sprite = block;
                tank1decor3.GetComponent<Image>().sprite = tick_block;
            }



        }
        else
        {
            if (themeID == 0)
            {
                tank2.sprite = tankthemes[0];

                tank2decor1.GetComponent<Image>().sprite = tick_block;
                tank2decor2.GetComponent<Image>().sprite = block;
                tank2decor3.GetComponent<Image>().sprite = block;
            }
            else if (themeID == 1)
            {
                tank2.sprite = tankthemes[1];

                tank2decor1.GetComponent<Image>().sprite = block;
                tank2decor2.GetComponent<Image>().sprite = tick_block;
                tank2decor3.GetComponent<Image>().sprite = block;
                
            }
            else if (themeID == 2)
            {
                tank2.sprite = tankthemes[2];

                tank2decor1.GetComponent<Image>().sprite = block;
                tank2decor2.GetComponent<Image>().sprite = block;
                tank2decor3.GetComponent<Image>().sprite = tick_block;
            }

        }
    }

    public void Start()
    {
        if (GameSpeed == 0)
        {
            GameSpeed = 1;
        }
    }


    public void ChangeGameSpeed(int speed)
    {
        if (speed == 1)
        {
            circle.GetComponent<RectTransform>().localPosition = x1.GetComponent<RectTransform>().localPosition += new Vector3(0, 1, 0);
            
        }
        else if (speed == 2)
        {
            circle.GetComponent<RectTransform>().localPosition = x2.GetComponent<RectTransform>().localPosition += new Vector3(0, 1, 0);
        }
        else if (speed == 3)
        {
            circle.GetComponent<RectTransform>().localPosition = x3.GetComponent<RectTransform>().localPosition += new Vector3(0, 1, 0);
        }
        
        
        GameSpeed = speed;
    }

}
