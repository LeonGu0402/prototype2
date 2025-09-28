using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    public GameManager gameManager;
    public SaveLoadManager saveLoadManager;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.SaveDataUpdate();
        saveLoadManager.SavePlayerData("checkPoint");
    }
}
