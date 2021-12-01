using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFishTank : MonoBehaviour
{
    public Transform TankOneTransform;
    public Transform TankTwoTransform;

    private void Start()
    {
        TankOneTransform = GameObject.Find("Tank01").transform;
        TankTwoTransform = GameObject.Find("Tank02").transform;
    }

    public void MoveFishToTankOne()
    {
        if (this.GetComponent<FishPanelInfo>().FishID.GetComponent<Fish>().hometankID == 2)
        {
            this.GetComponent<FishPanelInfo>().FishID.transform.position = TankOneTransform.position;
            Destroy(this.GetComponent<FishPanelInfo>().FishID.GetComponent<Fish>().MoveSpot);
            Destroy(this.gameObject);
        }
    }

    public void MoveFishToTankTwo()
    {
        if (this.GetComponent<FishPanelInfo>().FishID.GetComponent<Fish>().hometankID == 1)
        {
            this.GetComponent<FishPanelInfo>().FishID.transform.position = TankTwoTransform.position;
            Destroy(this.GetComponent<FishPanelInfo>().FishID.GetComponent<Fish>().MoveSpot);
            Destroy(this.gameObject);
        }
    }
}
