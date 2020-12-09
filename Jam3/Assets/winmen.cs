using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winmen : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("Hotel");
    }
    public void QuitGame()
    { Application.Quit();
    }

}

