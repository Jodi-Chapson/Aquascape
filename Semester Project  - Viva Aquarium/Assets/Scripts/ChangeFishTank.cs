using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFishTank : MonoBehaviour
{
    public Transform TankOneTransform;
    public Transform TankTwoTransform;
    public GameManager manager;
    private void Start()
    {
        manager = GameObject.Find("Bubble_Manager").GetComponent<GameManager>();
        TankOneTransform = GameObject.Find("Tank01").transform;
        TankTwoTransform = GameObject.Find("Tank02").transform;
    }

    //CapacityText.text = "Capacity : " + FishInTank + "/" + FishAllowed;

    public void MoveTanks()
    {
        InfoTankManager tank1 = GameObject.Find("Tank01").GetComponent<InfoTankManager>();
        InfoTankManager tank2 = GameObject.Find("Tank02").GetComponent<InfoTankManager>();
        
        if (this.GetComponent<FishPanelInfo>().FishID.GetComponent<Fish>().hometankID == 2)
        {
            tank1.FishInTank += 1;
            tank2.FishInTank -= 1;
            tank1.CapacityText.text = "Capacity : " + tank1.FishInTank + "/" + tank1.FishAllowed;
            tank2.CapacityText.text = "Capacity : " + tank2.FishInTank + "/" + tank2.FishAllowed;

            this.GetComponent<FishPanelInfo>().FishID.transform.position = TankOneTransform.position;
            Destroy(this.GetComponent<FishPanelInfo>().FishID.GetComponent<Fish>().MoveSpot);
            Destroy(this.gameObject);
        }
        else if (this.GetComponent<FishPanelInfo>().FishID.GetComponent<Fish>().hometankID == 1)
        {

            tank1.FishInTank -= 1;
            tank2.FishInTank += 1;
            tank1.CapacityText.text = "Capacity : " + tank1.FishInTank + "/" + tank1.FishAllowed;
            tank2.CapacityText.text = "Capacity : " + tank2.FishInTank + "/" + tank2.FishAllowed;

            this.GetComponent<FishPanelInfo>().FishID.transform.position = TankTwoTransform.position;
            Destroy(this.GetComponent<FishPanelInfo>().FishID.GetComponent<Fish>().MoveSpot);
            Destroy(this.gameObject);
        }
    }

   
}
