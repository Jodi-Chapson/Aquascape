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

    public GameObject Tank02_LockButton;
    public GameObject Tank02_LockedSprite;

    public GameObject Tank03_LockButton;
    public GameObject Tank03_LockedSprite;

    public GameObject Tank04_LockButton;
    public GameObject Tank04_LockedSprite;

    



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
        //Color newColor;
        //ColorUtility.TryParseHtmlString("#18A1DB", out newColor);


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
              Tank02_LockButton.SetActive(false);                   //Here we deactive the lock symbols and everything else on the tanks
              Tank02_LockedSprite.SetActive(false);
              
            }

            if (TankNumber == 3)                             
            {
                Tank03_LockButton.SetActive(false);
                Tank03_LockedSprite.SetActive(false);
                
            }

            if (TankNumber == 4)                              
            {
                Tank04_LockButton.SetActive(false);
                Tank04_LockedSprite.SetActive(false);
                
            }

       
        }
    }

}
