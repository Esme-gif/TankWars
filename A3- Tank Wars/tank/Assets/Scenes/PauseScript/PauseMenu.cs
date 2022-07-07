using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void clickResume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void clickRestart()
    {
        Debug.Log("loading menu");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
