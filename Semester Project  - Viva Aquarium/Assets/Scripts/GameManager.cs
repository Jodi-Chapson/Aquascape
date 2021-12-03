using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InfoTankManager[] tanks = new InfoTankManager[4]; //reference to all the relevant tanks, for assigning home tanks
    public GameObject[] fishtypes = new GameObject[4]; //reference to all the relevant fish prefabs
    public Sprite[] panelsprites = new Sprite[4]; // reference for all panel sprites
    public Sprite[] tankthemes = new Sprite[4]; // reference for all tank designs sprites
    public SpriteRenderer tank1, tank2;
    public Sprite block, tick_block;
    public GameObject tank1decor0, tank1decor1, tank1decor2, tank1decor3;
    public GameObject tank2decor0, tank2decor1, tank2decor2, tank2decor3;

    public RuntimeAnimatorController betta1, betta2, betta3;
    public int lastfish;
    

    public static List<GameObject> fish = new List<GameObject>();
    public int CurrentTankID;

    public static int GameSpeed;
    public GameObject circle;
    public GameObject x1, x2, x3;

    public static bool numbers;
    public GameObject onoff;

    public GameObject handbook;
    public GameObject leftscrollbutton, rightscrollbutton;
    public int currentpage;
    public GameObject[] bookpages = new GameObject[5]; //reference for all pages of aquarium handbook

    public void Start()
    {
        if (GameSpeed == 0)
        {
            GameSpeed = 1;
        }

        lastfish = 0;
        currentpage = 0;

        //change this later maybe 
            numbers = true;
        
        if (tanks[0].DecorationInt == 0)
        {
            tank1decor0.GetComponent<Image>().sprite = tick_block;
            tank1decor1.GetComponent<Image>().sprite = block;
            tank1decor2.GetComponent<Image>().sprite = block;
            tank1decor3.GetComponent<Image>().sprite = block;

        }
        else if (tanks[0].DecorationInt == 1)
        {
            tank1decor1.GetComponent<Image>().sprite = tick_block;
            tank1decor0.GetComponent<Image>().sprite = block;
            tank1decor2.GetComponent<Image>().sprite = block;
            tank1decor3.GetComponent<Image>().sprite = block;
        }
        else if (tanks[0].DecorationInt == 2)
        {
            tank1decor2.GetComponent<Image>().sprite = tick_block;
            tank1decor0.GetComponent<Image>().sprite = block;
            tank1decor1.GetComponent<Image>().sprite = block;
            tank1decor3.GetComponent<Image>().sprite = block;
        }
        else if (tanks[0].DecorationInt == 3)
        {
            tank1decor3.GetComponent<Image>().sprite = tick_block;
            tank1decor1.GetComponent<Image>().sprite = block;
            tank1decor2.GetComponent<Image>().sprite = block;
            tank1decor0.GetComponent<Image>().sprite = block;
        }

        if (tanks[1].DecorationInt == 0)
        {
            tank2decor0.GetComponent<Image>().sprite = tick_block;
            tank2decor1.GetComponent<Image>().sprite = block;
            tank2decor2.GetComponent<Image>().sprite = block;
            tank2decor3.GetComponent<Image>().sprite = block;
        }
        else if (tanks[1].DecorationInt == 1)
        {
            tank2decor1.GetComponent<Image>().sprite = tick_block;
            tank2decor0.GetComponent<Image>().sprite = block;
            tank2decor2.GetComponent<Image>().sprite = block;
            tank2decor3.GetComponent<Image>().sprite = block;
        }
        else if (tanks[1].DecorationInt == 2)
        {
            tank2decor2.GetComponent<Image>().sprite = tick_block;
            tank2decor1.GetComponent<Image>().sprite = block;
            tank2decor0.GetComponent<Image>().sprite = block;
            tank2decor3.GetComponent<Image>().sprite = block;
        }
        else if (tanks[1].DecorationInt == 3)
        {
            tank2decor3.GetComponent<Image>().sprite = tick_block;
            tank2decor1.GetComponent<Image>().sprite = block;
            tank2decor2.GetComponent<Image>().sprite = block;
            tank2decor0.GetComponent<Image>().sprite = block;
        }

    }

    public void ChangeThemeToInt (int themeID)
    {
        if (CurrentTankID == 1)
        {
            if (themeID == 0)
            {
                tank1.sprite = tankthemes[0];

                tank1decor0.GetComponent<Image>().sprite = tick_block;
                tank1decor1.GetComponent<Image>().sprite = block;
                tank1decor2.GetComponent<Image>().sprite = block;
                tank1decor3.GetComponent<Image>().sprite = block;
                
                tanks[0].DecorationInt = themeID;
            }
            else if (themeID == 1)
            {
                tank1.sprite = tankthemes[1];

                tank1decor0.GetComponent<Image>().sprite = block;
                tank1decor1.GetComponent<Image>().sprite = tick_block;
                tank1decor2.GetComponent<Image>().sprite = block;
                tank1decor3.GetComponent<Image>().sprite = block;
                tanks[0].DecorationInt = themeID;
            }
            else if (themeID == 2)
            {
                tank1.sprite = tankthemes[2];

                tank1decor0.GetComponent<Image>().sprite = block;
                tank1decor1.GetComponent<Image>().sprite = block;
                tank1decor2.GetComponent<Image>().sprite = tick_block;
                tank1decor3.GetComponent<Image>().sprite = block;
                tanks[0].DecorationInt = themeID;
            }
            else if (themeID == 3)
            {
                tank1.sprite = tankthemes[3];

                tank1decor0.GetComponent<Image>().sprite = block;
                tank1decor1.GetComponent<Image>().sprite = block;
                tank1decor2.GetComponent<Image>().sprite = block;
                tank1decor3.GetComponent<Image>().sprite = tick_block;
                tanks[0].DecorationInt = themeID;
            }
        }
        else
        {
            if (themeID == 0)
            {
                tank2.sprite = tankthemes[0];

                tank2decor0.GetComponent<Image>().sprite = tick_block;
                tank2decor1.GetComponent<Image>().sprite = block;
                tank2decor2.GetComponent<Image>().sprite = block;
                tank2decor3.GetComponent<Image>().sprite = block;
                tanks[1].DecorationInt = themeID;
            }
            else if (themeID == 1)
            {
                tank2.sprite = tankthemes[1];

                tank2decor0.GetComponent<Image>().sprite = block;
                tank2decor1.GetComponent<Image>().sprite = tick_block;
                tank2decor2.GetComponent<Image>().sprite = block;
                tank2decor3.GetComponent<Image>().sprite = block;
                tanks[1].DecorationInt = themeID;

            }
            else if (themeID == 2)
            {
                tank2.sprite = tankthemes[2];

                tank2decor0.GetComponent<Image>().sprite = block;
                tank2decor1.GetComponent<Image>().sprite = block;
                tank2decor2.GetComponent<Image>().sprite = tick_block;
                tank2decor3.GetComponent<Image>().sprite = block;
                tanks[1].DecorationInt = themeID;
            }
            else if (themeID == 3)
            {
                tank2.sprite = tankthemes[3];

                tank2decor0.GetComponent<Image>().sprite = block;
                tank2decor1.GetComponent<Image>().sprite = block;
                tank2decor2.GetComponent<Image>().sprite = block;
                tank2decor3.GetComponent<Image>().sprite = tick_block;
                tanks[1].DecorationInt = themeID;
            }
        }
    }

    public void RandomizeBetta(GameObject targetfish)
    {
        GameObject fish = targetfish;
        int random = Random.Range(1, 4);

        if (random == lastfish)
        {
            RandomizeBetta(fish);
            return;
        }
        


        if (random == 1)
        {
            targetfish.GetComponentInChildren<Animator>().runtimeAnimatorController = betta1;
            lastfish = random;
        }
        else if (random == 2)
        {
            targetfish.GetComponentInChildren<Animator>().runtimeAnimatorController = betta2;
            lastfish = random;
        }
        else if (random == 3)
        {
            targetfish.GetComponentInChildren<Animator>().runtimeAnimatorController = betta3;
            lastfish = random;
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

    public void ToggleNumbers()
    {
        if (numbers)
        {
            numbers = false;
            onoff.GetComponentInChildren<Text>().text = "OFF";
        }
        else
        {
            numbers = true;
            onoff.GetComponentInChildren<Text>().text = "ON";
        }
    }

    public void BrowseHandbook (int direction)
    {
        // 0 = left, 1 = right\
        // for the book pages: 0 = main page, 1 - 4 is fish pages

        if (direction == 0)
        {
            bookpages[currentpage].SetActive(false);
            bookpages[currentpage - 1].SetActive(true);

            currentpage -= 1;

            if (currentpage == 0)
            {
                leftscrollbutton.SetActive(false);
                
            }
            else
            {
                leftscrollbutton.SetActive(true);
            }
            rightscrollbutton.SetActive(true);
        }
        else if (direction == 1)
        {
            bookpages[currentpage].SetActive(false);
            bookpages[currentpage + 1].SetActive(true);

            currentpage += 1;

            if (currentpage == 4)
            {
                rightscrollbutton.SetActive(false);
            }
            else
            {
                rightscrollbutton.SetActive(true);
            }
            leftscrollbutton.SetActive(true);
        }
    }

    public void CloseBook()
    {
        if (currentpage != 0)
        {
            bookpages[currentpage].SetActive(false);
            bookpages[0].SetActive(true);
            currentpage = 0;
            rightscrollbutton.SetActive(true);
            leftscrollbutton.SetActive(false);

            
        }
        handbook.SetActive(false);
    }

    
}
