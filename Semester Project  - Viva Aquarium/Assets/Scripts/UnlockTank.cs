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
    public SpriteRenderer Tank2Background;

    public GameObject Tank3;
    public SpriteRenderer Tank3Background;

    public GameObject Tank4;
    public SpriteRenderer Tank4Background;

    public GameObject Fade02;
    public GameObject Fade03;
    public GameObject Fade04;



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
        Color newColor;
        ColorUtility.TryParseHtmlString("#18A1DB", out newColor);


        if (BubblesGenerated.bubbles < Price)        //Check if player has enough funds to purchase a tank
        {
            Panel.SetActive(true);
        }
        else if(BubblesGenerated.bubbles > Price)
        {
            BubblesGenerated.bubbles -= Price;
            Panel.SetActive(false);

            if (TankNumber == 2)                              
            {
              Tank2.SetActive(false);                   //Here we deactive the lock symbols and everything else on the tanks
              Tank2Background.color = newColor;
              Fade02.SetActive(true);
            }

            if (TankNumber == 3)                             
            {
                Tank3.SetActive(false);
                Tank3Background.color = newColor;
                Fade03.SetActive(true);
            }

            if (TankNumber == 4)                              
            {
                Tank4.SetActive(false);
                Tank4Background.color = newColor;
                Fade04.SetActive(true);
            }

       
        }
    }

}
