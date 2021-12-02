using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveManager : MonoBehaviour
{
    public static List<Fish> Fish = new List<Fish>();
    public GameObject[] FishTanks = new GameObject[2];

    const string FISH_SUB_PATH = "/fish";
    const string FISH_COUNT_PATH = "/fish.count";

    const string BUBBLES_PATH = "/bubbles";
    const string TANK_SUB_PATH = "/tank";

    [SerializeField] Fish Gold_Fish;
    [SerializeField] Fish Red_Tailed_Shark;
    [SerializeField] Fish Neon_Tetra;
    [SerializeField] Fish Betta;

    [SerializeField] GameManager gamemanager;

    public BoxCollider2D FishTankOneCollider;
    public BoxCollider2D FishTankTwoCollider;
    public int Count = 0;
    Vector2 Pos;
    float xPos;
    float yPos;

    /// <summary>
    /// Functions to save and load a fishes necessary data.
    /// </summary>
    ///

    private void Awake()
    {
        for (int i = 0; i < FishTanks.Length; i++)
            FishTanks[i] = GameObject.Find("Tank0" + (i + 1));

        LoadFishData();
        LoadNumberOfBubbles();
        LoadTankData();
    }

    //private void OnApplicationQuit()
    //{
    //    SaveFishData();
    //    SaveNumberOfBubbles();
    //    SaveTankData();
    //}

    public void SaveFishData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + FISH_SUB_PATH;           //Finds save path for us.
        string countpath = Application.persistentDataPath + FISH_COUNT_PATH;

        FileStream countfstream = new FileStream(countpath, FileMode.Create);
        formatter.Serialize(countfstream, Fish.Count);
        countfstream.Close();

        for (int i = 0; i < Fish.Count; i++)
        {
            FileStream fstream = new FileStream(savepath + i, FileMode.Create);
            FishData data = new FishData(Fish[i]);
            formatter.Serialize(fstream, data);                                    //Serializes it into binary to protect the data so that a player cannot modify data about the fish.
            fstream.Close();
        }

        Fish.Clear();
    }

    public void LoadFishData() //Will load the fishes data.
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + FISH_SUB_PATH;
        string countpath = Application.persistentDataPath + FISH_COUNT_PATH;
        int FishCount = 0;

        if (File.Exists(countpath))
        {
            FileStream countfstream = new FileStream(countpath, FileMode.Open);
            FishCount = (int)formatter.Deserialize(countfstream);
            countfstream.Close();
        }
        else
        {
            Debug.LogError("File path does not exist at " + FISH_COUNT_PATH);
        }

        for (int i = 0; i < FishCount; i++)
        {
            if (File.Exists(savepath + i))
            {
                FileStream fstream = new FileStream(savepath + i, FileMode.Open);
                FishData data = formatter.Deserialize(fstream) as FishData;
                fstream.Close();

                if (Count == 0 && data.Species == "Gold Fish")
                {
                    GameObject StartFish = GameObject.Find("Fish");
                    StartFish.GetComponent<Fish>().Level = data.Level;
                    StartFish.GetComponent<Fish>().Species = data.Species;
                    StartFish.GetComponent<Fish>().Happiness = data.Happiness;
                    StartFish.GetComponent<Fish>().hometankID = data.HomeTankID;
                    StartFish.GetComponent<Fish>().UpgradePrice = data.UpgradePrice;
                    Count++;
                }
                else
                {
                    Debug.Log(data.Species);

                    if (data.HomeTankID == 1)
                    {
                        xPos = Random.Range(FishTankOneCollider.bounds.min.x, FishTankOneCollider.bounds.max.x);
                        yPos = Random.Range(FishTankOneCollider.bounds.min.y, FishTankOneCollider.bounds.max.y);
                    }
                    else if (data.HomeTankID == 2)
                    {
                        xPos = Random.Range(FishTankTwoCollider.bounds.min.x, FishTankTwoCollider.bounds.max.x);
                        yPos = Random.Range(FishTankTwoCollider.bounds.min.y, FishTankTwoCollider.bounds.max.y);                  
                    }

                    Pos = new Vector2(xPos, yPos);


                    if (data.Species == "Gold Fish")
                    {
                        Debug.Log("Spawning gold fish");
                        Fish fish = Instantiate(Gold_Fish, Pos, Quaternion.identity);
                        fish.Level = data.Level;
                        fish.Species = data.Species;
                        fish.Happiness = data.Happiness;
                        fish.hometankID = data.HomeTankID;
                        fish.UpgradePrice = data.UpgradePrice;
                    }
                    else if (data.Species == "Red Tailed Shark")
                    {
                        Debug.Log("Spawning RTS");
                        Fish fish = Instantiate(Red_Tailed_Shark, Pos, Quaternion.identity);
                        fish.Level = data.Level;
                        fish.Species = data.Species;
                        fish.Happiness = data.Happiness;
                        fish.hometankID = data.HomeTankID;
                        fish.UpgradePrice = data.UpgradePrice;
                    }
                    else if (data.Species == "Neon Tetra")
                    {
                        Fish fish = Instantiate(Neon_Tetra, Pos, Quaternion.identity);
                        fish.Level = data.Level;
                        fish.Species = data.Species;
                        fish.Happiness = data.Happiness;
                        fish.hometankID = data.HomeTankID;
                        fish.UpgradePrice = data.UpgradePrice;
                    }
                    else if (data.Species == "Betta")
                    {
                        Fish fish = Instantiate(Betta, Pos, Quaternion.identity);
                        fish.Level = data.Level;
                        fish.Species = data.Species;
                        fish.Happiness = data.Happiness;
                        fish.hometankID = data.HomeTankID;
                        fish.UpgradePrice = data.UpgradePrice;
                    }
                }
            }
            else
            {
                Debug.LogError("File does not exist at " + FISH_SUB_PATH);
            }
        }
    }



    public void SaveNumberOfBubbles()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + BUBBLES_PATH;
        FileStream fstream = new FileStream(savepath, FileMode.Create);

        formatter.Serialize(fstream, BubblesGenerated.bubbles);
        fstream.Close();
    }

    public void LoadNumberOfBubbles()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + BUBBLES_PATH;

        if (File.Exists(savepath))
        {
            FileStream fStream = new FileStream(savepath, FileMode.Open);
            BubblesGenerated.bubbles = (double)formatter.Deserialize(fStream);
            fStream.Close();
        }
        else
        {
            Debug.Log("File not found at " + savepath);
        }
    }


    public void SaveTankData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + TANK_SUB_PATH;

        for (int i = 0; i < FishTanks.Length; i++)
        {
            FileStream fstream = new FileStream(savepath + i, FileMode.Create);
            TankData data = new TankData(FishTanks[i].GetComponent<InfoTankManager>());
            formatter.Serialize(fstream, data);
            fstream.Close();
        }
    }
    
    public void LoadTankData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + TANK_SUB_PATH;

        for (int i = 0; i < FishTanks.Length; i++)
        {
            if (File.Exists(savepath + i))
            {
                FileStream fstream = new FileStream(savepath + i, FileMode.Open);
                TankData data = formatter.Deserialize(fstream) as TankData;
                fstream.Close();

                FishTanks[i].GetComponent<InfoTankManager>().Unlocked = data.Unlocked;
                FishTanks[i].GetComponent<InfoTankManager>().FishInTank = data.TankCapacity;
                FishTanks[i].GetComponent<InfoTankManager>().TankLevel = data.TankLevel;
                FishTanks[i].GetComponent<InfoTankManager>().UpgradeTankPrice = data.UpgradePrice;
                FishTanks[i].GetComponent<InfoTankManager>().FishAllowed = data.FishAllowed;
                FishTanks[i].GetComponent<InfoTankManager>().TankID = data.TankID;
                FishTanks[i].GetComponent<InfoTankManager>().DecorationInt = data.DecorationInt;

                if (FishTanks[i].GetComponent<InfoTankManager>().TankLevel == 1)
                {
                    FishTanks[i].GetComponent<InfoTankManager>().Decor2_button.SetActive(true);
                }
                else if (FishTanks[i].GetComponent<InfoTankManager>().TankLevel == 2)
                {
                    FishTanks[i].GetComponent<InfoTankManager>().Decor2_button.SetActive(true);
                    FishTanks[i].GetComponent<InfoTankManager>().Decor3_button.SetActive(true);
                }

                else if (FishTanks[i].GetComponent<InfoTankManager>().TankLevel == 3)
                {
                    FishTanks[i].GetComponent<InfoTankManager>().UpgradeButton.SetActive(false);
                    FishTanks[i].GetComponent<InfoTankManager>().UpgradePrice.gameObject.SetActive(false);
                    FishTanks[i].GetComponent<InfoTankManager>().TankLevelText.text = "Tank Level : 3 (MAX)";
                    FishTanks[i].GetComponent<InfoTankManager>().Decor2_button.SetActive(true);
                    FishTanks[i].GetComponent<InfoTankManager>().Decor3_button.SetActive(true);
                    FishTanks[i].GetComponent<InfoTankManager>().Decor4_button.SetActive(true);
                }

                if (FishTanks[i].name == "Tank01")
                {
                    if (FishTanks[i].GetComponent<InfoTankManager>().DecorationInt == 0)
                    {
                        gamemanager.tank1.sprite = gamemanager.tankthemes[0];

                        gamemanager.tank1decor1.GetComponent<Image>().sprite = gamemanager.tick_block;
                        gamemanager.tank1decor2.GetComponent<Image>().sprite = gamemanager.block;
                        gamemanager.tank1decor3.GetComponent<Image>().sprite = gamemanager.block;

                    }
                    else if (FishTanks[i].GetComponent<InfoTankManager>().DecorationInt == 1)
                    {
                        gamemanager.tank1.sprite = gamemanager.tankthemes[1];

                        gamemanager.tank1decor1.GetComponent<Image>().sprite = gamemanager.tick_block;
                        gamemanager.tank1decor2.GetComponent<Image>().sprite = gamemanager.block;
                        gamemanager.tank1decor3.GetComponent<Image>().sprite = gamemanager.block;
                    }
                    else if (FishTanks[i].GetComponent<InfoTankManager>().DecorationInt == 2)
                    {
                        gamemanager.tank1.sprite = gamemanager.tankthemes[2];

                        gamemanager.tank1decor1.GetComponent<Image>().sprite = gamemanager.tick_block;
                        gamemanager.tank1decor2.GetComponent<Image>().sprite = gamemanager.block;
                        gamemanager.tank1decor3.GetComponent<Image>().sprite = gamemanager.block;
                    }
                    else if (FishTanks[i].GetComponent<InfoTankManager>().DecorationInt == 3)
                    {
                        gamemanager.tank1.sprite = gamemanager.tankthemes[3];

                        gamemanager.tank1decor1.GetComponent<Image>().sprite = gamemanager.tick_block;
                        gamemanager.tank1decor2.GetComponent<Image>().sprite = gamemanager.block;
                        gamemanager.tank1decor3.GetComponent<Image>().sprite = gamemanager.block;
                    }
                }
                else
                {
                    if (FishTanks[i].GetComponent<InfoTankManager>().DecorationInt == 0)
                    {
                        gamemanager.tank2.sprite = gamemanager.tankthemes[0];

                        gamemanager.tank2decor1.GetComponent<Image>().sprite = gamemanager.tick_block;
                        gamemanager.tank2decor2.GetComponent<Image>().sprite = gamemanager.block;
                        gamemanager.tank2decor3.GetComponent<Image>().sprite = gamemanager.block;
                    }
                    else if (FishTanks[i].GetComponent<InfoTankManager>().DecorationInt == 1)
                    {
                        gamemanager.tank2.sprite = gamemanager.tankthemes[1];

                        gamemanager.tank2decor1.GetComponent<Image>().sprite = gamemanager.tick_block;
                        gamemanager.tank2decor2.GetComponent<Image>().sprite = gamemanager.block;
                        gamemanager.tank2decor3.GetComponent<Image>().sprite = gamemanager.block;
                    }
                    else if (FishTanks[i].GetComponent<InfoTankManager>().DecorationInt == 2)
                    {
                        gamemanager.tank2.sprite = gamemanager.tankthemes[2];

                        gamemanager.tank2decor1.GetComponent<Image>().sprite = gamemanager.tick_block;
                        gamemanager.tank2decor2.GetComponent<Image>().sprite = gamemanager.block;
                        gamemanager.tank2decor3.GetComponent<Image>().sprite = gamemanager.block;
                    }
                    else if (FishTanks[i].GetComponent<InfoTankManager>().DecorationInt == 3)
                    {
                        gamemanager.tank2.sprite = gamemanager.tankthemes[3];

                        gamemanager.tank2decor1.GetComponent<Image>().sprite = gamemanager.tick_block;
                        gamemanager.tank2decor2.GetComponent<Image>().sprite = gamemanager.block;
                        gamemanager.tank2decor3.GetComponent<Image>().sprite = gamemanager.block;
                    }
                }


                if (i == 1 && FishTanks[1].GetComponent<InfoTankManager>().Unlocked)
                {
                    GameObject.Find("Tanks").GetComponent<UnlockTank>().Tank02_LockButton.SetActive(false);
                    GameObject.Find("Tanks").GetComponent<UnlockTank>().Tank02_LockedSprite.SetActive(false);
                    GameObject.Find("Tanks").GetComponent<UnlockTank>().Tank02_InfoButton.SetActive(true);
                }
            }
            else
            {
                Debug.Log("The file does not exist at " + TANK_SUB_PATH);
            }
        }
    }
}
