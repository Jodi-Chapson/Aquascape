using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanScript : MonoBehaviour
{
    public GameObject tank1, tank2, tank3, tank4;
    public GameObject LeftScrollButton, RightScrollButton;

    public int CurrentTankID;
    public float TargetXValue;
    public float Lerp;
    public float StartingLerp;
    public int LatestTankUnlocked;
    

    
    public void Start()
    {
        CurrentTankID = 1;
        Lerp = 1;
        
        
        TargetXValue = tank1.transform.position.x;
    }
    public void Update()
    {

        float targetx = Mathf.Lerp(this.transform.position.x, TargetXValue, Lerp);
        this.transform.position = new Vector3(targetx, this.transform.position.y, this.transform.position.z);

        if (Lerp < 1)
        {
            Lerp += 0.01f;
        }
        
        
        
        
        
        if (CurrentTankID == 1)
        {
            LeftScrollButton.gameObject.SetActive(false);
        }
        else
        {
            LeftScrollButton.gameObject.SetActive(true);
        }

        if (CurrentTankID == 4)
        {
            RightScrollButton.gameObject.SetActive(false);
        }
        else
        {
            RightScrollButton.gameObject.SetActive(true);
        }
    }

    public void MoveCamera(int direction)
    {
        // 0 = left, 1 = right


        if ( direction == 0)
        {
            //moving to the tank on the left

            if (CurrentTankID == 2)
            {
                TargetXValue = tank1.transform.position.x;
                Lerp = StartingLerp;
                
                CurrentTankID = 1;
            }
            else if (CurrentTankID == 3)
            {
                TargetXValue = tank2.transform.position.x;
                Lerp = StartingLerp;
                CurrentTankID = 2;
            }
            else if (CurrentTankID == 4)
            {
                TargetXValue = tank3.transform.position.x;
                Lerp = StartingLerp;
                CurrentTankID = 3;
            }


        }
        else if (direction == 1)
        {
            //moving to the tank on the right

            if (CurrentTankID == 1)
            {
                TargetXValue = tank2.transform.position.x;
                Lerp = StartingLerp;
                CurrentTankID = 2;
            }
            else if (CurrentTankID == 2)
            {
                TargetXValue = tank3.transform.position.x;
                Lerp = StartingLerp;
                CurrentTankID = 3;
            }
            else if (CurrentTankID == 3)
            {
                TargetXValue = tank4.transform.position.x;
                Lerp = StartingLerp;
                CurrentTankID = 4;
            }



        }




    }



}
