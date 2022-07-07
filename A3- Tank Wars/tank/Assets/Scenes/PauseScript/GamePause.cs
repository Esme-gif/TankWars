using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject overMenu;

    public void ClickedPause()
    {
        pauseMenu.SetActive(true);
        overMenu.SetActive(false);
        Time.timeScale = 0;
    }
}
