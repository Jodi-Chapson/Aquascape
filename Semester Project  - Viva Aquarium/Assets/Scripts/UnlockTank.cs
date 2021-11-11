using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockTank : MonoBehaviour
{
    public int Price = 0;
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
        if (BubbleManager.Count <= Price)            //Cant unlock tank if you do not have sufficient bubbles
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(true);
        }
    }
}
