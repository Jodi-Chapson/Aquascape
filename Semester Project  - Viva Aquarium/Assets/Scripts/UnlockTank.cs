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
    public GameObject Tank02_InfoButton;
    public GameObject Tank02_Dirt;

    public void Tank02()
    {
        Price = 3000;
        PriceText.text = "" + Price;

        TankNumber = 2;
    }

    public void Yes()
    {
        //Color newColor;
        //ColorUtility.TryParseHtmlString("#18A1DB", out newColor);


        if (BubblesGenerated.bubbles < Price)        //Check if player has enough funds to purchase a tank
        {
            Panel.SetActive(true);
        }
        else if (BubblesGenerated.bubbles > Price)
        {
            BubblesGenerated.bubbles -= Price;
            Panel.SetActive(false);

            if (TankNumber == 2)
            {
                Tank02_LockButton.SetActive(false);                   //Here we deactive the lock symbols and everything else on the tanks
                Tank02_LockedSprite.SetActive(false);
                Tank02_InfoButton.SetActive(true);
                Tank02_Dirt.SetActive(true);
                GameObject.Find("Tank02").GetComponent<InfoTankManager>().Unlocked = true;
            }


        }
    }

}
