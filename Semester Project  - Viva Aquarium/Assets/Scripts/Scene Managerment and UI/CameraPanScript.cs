using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanScript : MonoBehaviour
{
    public GameObject tank1, tank2, tank3, tank4;
    public int CurrentTankID;
    public int LatestTankUnlocked;
    public GameObject LeftScrollButton, RightScrollButton;

    
    public void Start()
    {
        CurrentTankID = 1;
    }
    public void Update()
    {
        
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
                this.gameObject.transform.position = new Vector3(tank1.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                CurrentTankID = 1;
            }
            else if (CurrentTankID == 3)
            {
                this.gameObject.transform.position = new Vector3(tank2.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                CurrentTankID = 2;
            }
            else if (CurrentTankID == 4)
            {
                this.gameObject.transform.position = new Vector3(tank3.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                CurrentTankID = 3;
            }


        }
        else if (direction == 1)
        {
            //moving to the tank on the right

            if (CurrentTankID == 1)
            {
                this.gameObject.transform.position = new Vector3(tank2.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                CurrentTankID = 2;
            }
            else if (CurrentTankID == 2)
            {
                this.gameObject.transform.position = new Vector3(tank3.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                CurrentTankID = 3;
            }
            else if (CurrentTankID == 3)
            {
                this.gameObject.transform.position = new Vector3(tank4.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                CurrentTankID = 4;
            }



        }




    }



}
