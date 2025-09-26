using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializationManager : MonoBehaviour
{
    public ObjectManager objectManager;

    public string savePath;


    [ContextMenu("Display data path")]
    public void DisplayDataPath()
    {
        Debug.Log(Application.dataPath);
    }

    public void SaveData()
    {
        //no data or no path
        if (objectManager == null || savePath == "")
        {
            return;
        }

        using (StreamWriter streamWriter = new StreamWriter(savePath))
        {
            //transform objectData into json form then to string
            string data = JsonUtility.ToJson(objectManager.objectData);
            streamWriter.Write(data);
        }

        Debug.Log("Successfully Save");
    }

    public void LoadData()
    {
        //no data
        if (savePath == "")
        {
            return;
        }
        //creating emprty string
        string json = string.Empty;

        using (StreamReader streamReader = new StreamReader(savePath))
        {
            //read data
            json = streamReader.ReadLine();
            Debug.Log(json);
            objectManager.objectData = JsonUtility.FromJson<ObjectData>(json);
        }

        Debug.Log("Successfully Load");
    }

    
}
