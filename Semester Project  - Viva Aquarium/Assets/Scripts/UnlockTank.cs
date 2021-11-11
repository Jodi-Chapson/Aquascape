using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockTank : MonoBehaviour
{
    public static int Price;
    public Text PriceText;
    public GameObject Panel;

    
   public void Tank02()
    {
        Price = 1000;
        PriceText.text = "" + Price;
    }

    public void Tank03()
    {
        Price = 3000;
        PriceText.text = "" + Price;
    }

    public void Tank04()
    {
        Price = 9000;
        PriceText.text = "" + Price;
    }

    public void Yes() 
    {
        if(BubblesGenerated.bubbles < Price)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);

            BubblesGenerated.bubbles -= Price;
        }
    }
}
