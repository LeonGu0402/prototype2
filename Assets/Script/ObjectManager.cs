using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject readObject;
    public ObjectData objectData;


    
    void Start()
    {

    }

    void Update()
    {
        //objectData.objectName = readObject.name;
        //objectData.objectTransform = readObject.transform;
    }

    public void SaveDataUpdate()
    {
        objectData.objectName = readObject.name;
        objectData.objectPosition = readObject.transform.position;
        objectData.objectRotation = readObject.transform.rotation;
        objectData.objectScale = readObject.transform.localScale;
    }

    public void LoadDataUpdate()
    {
        readObject.name = objectData.objectName;
        //updating transform
        readObject.transform.position = objectData.objectPosition;
        readObject.transform.rotation = objectData.objectRotation;
        readObject.transform.localScale = objectData.objectScale;
    }
}
