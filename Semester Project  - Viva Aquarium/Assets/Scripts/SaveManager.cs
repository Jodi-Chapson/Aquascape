using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveManager: MonoBehaviour
{
    public static List<Fish> Fish = new List<Fish>();
    const string FISH_SUB_PATH = "/fish";
    const string FISH_COUNT_PATH = "/fish.count";
    const string BUBBLES_PATH = "/bubbles";
    const string TANK_SUB_PATH = "/tank";

    [SerializeField] Fish Gold_Fish;
    [SerializeField] Fish Red_Tailed_Shark;
    [SerializeField] Fish Exodon;
    [SerializeField] Fish Neon_Tetra;
    public BoxCollider2D FishTankCollider;
    public GameObject FishTank;
    /// <summary>
    /// Functions to save and load a fishes necessary data.
    /// </summary>
    ///

    private void Awake()
    {
        LoadFishData();
        LoadNumberOfBubbles();
        LoadTankData();

        Debug.Log(Application.persistentDataPath);
    }

    private void OnApplicationQuit()
    {
       SaveFishData();
       SaveNumberOfBubbles();
       SaveTankData();
    }

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

                if (i == 0)
                {
                    GameObject StartFish = GameObject.Find("Fish");
                    StartFish.GetComponent<Fish>().Level = data.Level;
                    StartFish.GetComponent<Fish>().Species = data.Species;
                    StartFish.GetComponent<Fish>().Happiness = data.Happiness;
                }
                else
                {
                    float xPos = Random.Range(FishTankCollider.bounds.min.x, FishTankCollider.bounds.max.x);
                    float yPos = Random.Range(FishTankCollider.bounds.min.y, FishTankCollider.bounds.max.y);

                    Vector2 Pos = new Vector2(xPos, yPos);

                    if (data.Species == "Gold Fish")
                    {
                        Fish fish = Instantiate(Gold_Fish, Pos, Quaternion.identity);
                        fish.Level = data.Level;
                        fish.Species = data.Species;
                        fish.Happiness = data.Happiness;
                    } 
                    else if (data.Species == "Red Tailed Shark")
                    {
                        Fish fish = Instantiate(Red_Tailed_Shark, Pos, Quaternion.identity);
                        fish.Level = data.Level;
                        fish.Species = data.Species;
                        fish.Happiness = data.Happiness;
                    }
                    else if (data.Species == "Exodon")
                    {
                        Fish fish = Instantiate(Exodon, Pos, Quaternion.identity);
                        fish.Level = data.Level;
                        fish.Species = data.Species;
                        fish.Happiness = data.Happiness;
                    }
                    else if (data.Species == "Neon Tetra")
                    {
                        Fish fish = Instantiate(Neon_Tetra, Pos, Quaternion.identity);
                        fish.Level = data.Level;
                        fish.Species = data.Species;
                        fish.Happiness = data.Happiness;
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
        FileStream fstream = new FileStream(savepath, FileMode.Create);
        formatter.Serialize(fstream, FishTank.GetComponent<InfoTankManager>().FishInTank);
        fstream.Close();
    }

    public void LoadTankData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + TANK_SUB_PATH;

        if (File.Exists(savepath))
        {
            FileStream fstream = new FileStream(savepath, FileMode.Open);
            FishTank.GetComponent<InfoTankManager>().FishInTank = (float)formatter.Deserialize(fstream);
            fstream.Close();
        }
        else
        {
            Debug.Log("The file does not exist at " + TANK_SUB_PATH);
        }
    }



    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    /// <summary>
    /// Functions to save the data for the tank and load the tanks data
    /// </summary>

    //public static void SaveTankData(InfoTank01 tank)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string savepath = Application.persistentDataPath + "/tank.txt";
    //    FileStream fstream = new FileStream(savepath, FileMode.Create);
    //    TankData data = new TankData(tank);
    //    formatter.Serialize(fstream, data);
    //    fstream.Close();
    //}

    //public static TankData LoadTankData()
    //{
    //    string savepath = Application.persistentDataPath + "/tank.txt";

    //    if (File.Exists(savepath))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream fstream = new FileStream(savepath, FileMode.Open);
    //        TankData data = formatter.Deserialize(fstream) as TankData;
    //        fstream.Close();
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.Log("File does not exist.");
    //        return null;
    //    }
    //}

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}
