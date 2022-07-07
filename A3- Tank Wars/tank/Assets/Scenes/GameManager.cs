using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int numTeams;
    private int numTanks;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject OverMenu;
    public GameObject Noone;
    public GameObject BlueT;
    public GameObject RedT;
    public GameObject GreenT;
    private GameObject[] spawnPoints;
    private GameObject[] spawnRed;
    private GameObject[] spawnGreen;

    bool isPlayer1Dead = false;
    bool isPlayer2Dead = false;
    bool isPlayer3Dead = false;

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnRed = GameObject.FindGameObjectsWithTag("SpawnRed");
        spawnGreen = GameObject.FindGameObjectsWithTag("SpawnGreen");


        numTeams = PlayerPrefs.GetInt("numOfTeams");
        numTanks = PlayerPrefs.GetInt("numOfTanks");
        if (numTeams == 2)
        {
            Spawnblue();
            Spawnred();
        }
        else
        {
            Spawnblue();
            Spawnred();
            Spawngreen();
        }
        
    }


    void Update()
    {
        if (isPlayer1Dead && isPlayer2Dead && isPlayer3Dead)
        {
            Time.timeScale = 0;
            OverMenu.SetActive(true);
            Noone.SetActive(true);
            GreenT.SetActive(false);
            BlueT.SetActive(false);
            RedT.SetActive(false);
            
        }
        else if (isPlayer2Dead && isPlayer3Dead)
        {
            Time.timeScale = 0;
            OverMenu.SetActive(true);
            BlueT.SetActive(true);
            GreenT.SetActive(false);
            RedT.SetActive(false);
            Noone.SetActive(false);
        }
        else if (isPlayer1Dead && isPlayer3Dead)
        {
            Time.timeScale = 0;
            OverMenu.SetActive(true);
            RedT.SetActive(true);
            GreenT.SetActive(false);
            BlueT.SetActive(false);
            Noone.SetActive(false);
        }
        else if (isPlayer1Dead && isPlayer2Dead )
        {
            Time.timeScale = 0;
            OverMenu.SetActive(true);
            GreenT.SetActive(true);
            BlueT.SetActive(false);
            RedT.SetActive(false);
            Noone.SetActive(false);
        }

        if (GameObject.FindWithTag("Player1") == null && isPlayer1Dead == false)
        {
            isPlayer1Dead = true;
              
        }                               
        if (GameObject.FindWithTag("Player2") == null && isPlayer2Dead == false)
        {
            isPlayer2Dead = true;
           
        }
        if (GameObject.FindWithTag("Player3") == null && isPlayer3Dead == false)
        {
            isPlayer3Dead = true;
            
        }
    }

    void Spawnblue()
    {
        if (numTanks == 1) {
            GameObject.Instantiate(player1, spawnPoints[0].transform.position, Quaternion.identity);
        }
        else{
            GameObject.Instantiate(player1, spawnPoints[0].transform.position, Quaternion.identity);
            GameObject.Instantiate(player1, spawnPoints[1].transform.position, Quaternion.identity);
        }
        
    }
    void Spawnred()
    {
        if (numTanks == 1)
        {
            GameObject.Instantiate(player2, spawnRed[0].transform.position, Quaternion.identity);
        }
        else
        {
            GameObject.Instantiate(player2, spawnRed[0].transform.position, Quaternion.identity);
            GameObject.Instantiate(player2, spawnRed[1].transform.position, Quaternion.identity);
        }
        
    }
    void Spawngreen()
    {
        if (numTanks == 1)
        {
            GameObject.Instantiate(player3, spawnGreen[0].transform.position, Quaternion.identity);
        }
        else
        {
            GameObject.Instantiate(player3, spawnGreen[0].transform.position, Quaternion.identity);
            GameObject.Instantiate(player3, spawnGreen[1].transform.position, Quaternion.identity);
        }
        
    }
    public void clicRestart()
    {
        OverMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
