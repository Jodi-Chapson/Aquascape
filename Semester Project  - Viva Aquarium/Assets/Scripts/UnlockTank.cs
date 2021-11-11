using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockTank : MonoBehaviour
{
    public static int Price;
    public Text PriceText;
    public GameObject Panel;

    public static int TankNumber;

    public GameObject Tank2;
    public GameObject Tank2Background;

    public GameObject Tank3;
    public GameObject Tank3Background;

    public GameObject Tank4;
    public GameObject Tank4Background;


    public void Tank02()
    {
        Price = 1000;
        PriceText.text = "" + Price;

        TankNumber = 2;
    }

    public void Tank03()
    {
        Price = 3000;
        PriceText.text = "" + Price;

        TankNumber = 3;
    }

    public void Tank04()
    {
        Price = 9000;
        PriceText.text = "" + Price;

        TankNumber = 4;
    }

    public void Yes() 
    {
        if(BubblesGenerated.bubbles < Price)        //Check if player has enough funds to purchase a tank
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);

            BubblesGenerated.bubbles -= Price;
        }


        if(TankNumber == 2)                              //Here we deactive the lock symbols and everything else on the tanks
        {
            Tank2.SetActive(false);
        }

        if (TankNumber == 3)
        {
            Tank3.SetActive(false);
        }

        if (TankNumber == 4)
        {
            Tank4.SetActive(false);
        }
    }
}
