using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winmen : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("HarryHotel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}

