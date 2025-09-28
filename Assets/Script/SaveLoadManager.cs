using Platformer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public GameManager gameManager;
    public string savePath;
    private string fileSaveLocation;

    private void Update()
    {
        
    }

    [ContextMenu("Display data path")]
    public void DisplayDataPath()
    {
        Debug.Log(fileSaveLocation);
    }

    //public void Slot1()
    //{
    //    saveIndex = 0;
    //}
    //public void Slot2()
    //{
    //    saveIndex = 1;
    //}
    //public void Slot3()
    //{
    //    saveIndex = 2;
    //}
    //public void Slot4()
    //{
    //    saveIndex = 3;
    //}
    //public void Slot5()
    //{
    //    saveIndex = 4;
    //}

    public void SavePlayerData(string saveIndex)
    {
        fileSaveLocation = savePath + "/" + saveIndex + " PlayerSave";

        //no data or no path
        if (gameManager == null || fileSaveLocation == "")
        {
            return;
        }

        using (StreamWriter streamWriter =  new StreamWriter(fileSaveLocation))
        {
            string playerData = JsonUtility.ToJson(gameManager.playerData);
            streamWriter.Write(playerData);
        }

        Debug.Log("Player file saved");
    }

    public void LoadPlayerData(string saveIndex)
    {
        fileSaveLocation = savePath + "/" + saveIndex + " PlayerSave";

        if (fileSaveLocation == "")
        {
            return;
        }

        string json = string.Empty;

        using (StreamReader streamReader = new StreamReader(fileSaveLocation))
        {
            json = streamReader.ReadLine();
            Debug.Log(json);
            gameManager.playerData = JsonUtility.FromJson<PlayerData>(json);
        }


        Debug.Log("Player file loaded");
    }
}
