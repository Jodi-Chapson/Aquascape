using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveManager
{

    /// <summary>
    /// Functions to save and load a fishes necessary data.
    /// </summary>
    public static void SaveFishData(/*Fish fish*/) //Saves the fish data. Will be used in a fish class.
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + "/fish.txt"; //Finds save path for us.
        FileStream fstream = new FileStream(savepath, FileMode.Create); //Creates the file that needs to be saved in a directory.
        FishData data = new FishData(/*fish*/); //Need to pass the fish class in here.
        formatter.Serialize(fstream, data); //Serializes it into binary to protect the data so that a player cannot modify data about the fish.
        fstream.Close();
    }

    public static FishData LoadFishData() //Will load the fishes data. Will be used in a fish class.
    {
        string savepath = Application.persistentDataPath + "/fish.txt";

        if (File.Exists(savepath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fstream = new FileStream(savepath, FileMode.Open);
            FishData data = formatter.Deserialize(fstream) as FishData;
            fstream.Close();
            return data;
        }
        else
        {
            Debug.Log("File does not exist");
            return null;
        }
    }



    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    

    /// <summary>
    /// Functions to save the data for the tank and load the tanks data
    /// </summary>

    public static void SaveTankData(/*Tank tank*/)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepath = Application.persistentDataPath + "/tank.txt";
        FileStream fstream = new FileStream(savepath, FileMode.Create);
        TankData data = new TankData(/*tank*/);
        formatter.Serialize(fstream, data);
        fstream.Close();
    }

    public static TankData LoadTankData()
    {
        string savepath = Application.persistentDataPath + "/tank.txt";

        if (File.Exists(savepath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fstream = new FileStream(savepath, FileMode.Open);
            TankData data = formatter.Deserialize(fstream) as TankData;
            fstream.Close();
            return data;
        }
        else
        {
            Debug.Log("File does not exist.");
            return null;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
}
