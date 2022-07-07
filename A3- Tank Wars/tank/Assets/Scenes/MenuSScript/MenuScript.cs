using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public int DefaultTeams;
    public int DefaultTanks;


    public GameObject firstpart;
    public GameObject secondpart;
    public GameObject thirdpart;


    public void selectTeamsbvr()
    {
        DefaultTeams = 2;
        
        firstpart.SetActive(false);
        secondpart.SetActive(true);

    }

    public void selectTeamsbvrvg()
    {
        DefaultTeams = 3;
       
        firstpart.SetActive(false);
        secondpart.SetActive(true);
    }

    public void selectTanksone()
    {
        DefaultTanks = 1;
      
        secondpart.SetActive(false);
        thirdpart.SetActive(true);
    }

    public void selectTankstwo()
    {
        DefaultTanks = 2;
        
        secondpart.SetActive(false);
        thirdpart.SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("numOfTanks", DefaultTanks);
        PlayerPrefs.SetInt("numOfTeams", DefaultTeams);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void backButton()
    {
        if (secondpart.activeSelf)
        {
            secondpart.SetActive(false);
            firstpart.SetActive(true);
        }
        else if (thirdpart.activeSelf)
        {
            thirdpart.SetActive(false);
            secondpart.SetActive(true);
        }
    }
}
