using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public void MonsterKill()
    {
        SceneManager.LoadScene("GameOverMonster", LoadSceneMode.Single);
    }

    public void Escape()
    {
        SceneManager.LoadScene("GameOverEscape", LoadSceneMode.Single);
    }
}
