using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMen : MonoBehaviour
{
    // Start is called before the first frame update
    public void restartGame()
    {
        SceneManager.LoadScene("Hotel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
