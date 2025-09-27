using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public GameObject playerGameObject;
        public PlayerController player;
        public GameObject deathPlayerPrefab;
        public Text coinText;

        public List <GameObject> coinList;

        [Header("player data")]
        public PlayerData playerData;


        void Start()
        {
            //player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();
            if(player.deathState == true)
            {
                playerGameObject.SetActive(false);
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                player.deathState = false;
                //Invoke("ReloadLevel", 3);
            }
        }

        //private void ReloadLevel()
        //{
        //    Application.LoadLevel(Application.loadedLevel);

        //}

        public void SaveDataUpdate()
        {
            playerData.isDead = player.deathState;
            playerData.coin1Collect = coinList[0].activeSelf;
            playerData.coin2Collect = coinList[1].activeSelf;
            playerData.coin3Collect = coinList[2].activeSelf;

            playerData.coinNumber = coinsCounter;
            playerData.playerPosition = playerGameObject.transform.position;
            playerData.playerRotation = playerGameObject.transform.rotation;
            playerData.playerScale = playerGameObject.transform.localScale;
        }

        public void LoadDataUpdate()
        {
            //make player alive
            if (playerData.isDead == false)
            {
                playerGameObject.SetActive (true);
            }

            coinList[0].SetActive(playerData.coin1Collect);
            coinList[1].SetActive(playerData.coin2Collect);
            coinList[2].SetActive(playerData.coin3Collect);


            GameObject deadPlayer = GameObject.FindWithTag("DeadPlayer");
            Destroy(deadPlayer);

            coinsCounter = playerData.coinNumber;
            playerGameObject.transform.position = playerData.playerPosition;
            playerGameObject.transform.rotation = playerData.playerRotation;
            playerGameObject.transform.localScale = playerData.playerScale;
        }
    }
}
