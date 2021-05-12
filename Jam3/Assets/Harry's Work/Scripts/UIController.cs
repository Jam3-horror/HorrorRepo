using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Pointer Setup")]
    public GameObject playPointer;
    public GameObject optionsPointer;
    public GameObject creditsPointer;
    public GameObject quitPointer;
    
    private void Start() 
    {
        playPointer.SetActive(false);
        optionsPointer.SetActive(false);
        creditsPointer.SetActive(false);
        quitPointer.SetActive(false);
    }

    // Play pointer
    public void PPOn()
    {
        playPointer.SetActive(true);
    }

    public void PPOff()
    {
        playPointer.SetActive(false);
    }

    // Options pointer
    public void OPOn()
    {
        optionsPointer.SetActive(true);
    }

    public void OPOff()
    {
        optionsPointer.SetActive(false);
    }

    // Credits pointer
    public void CPOn()
    {
        creditsPointer.SetActive(true);
    }

    public void CPOff()
    {
        creditsPointer.SetActive(false);
    }

    // Quit pointer
    public void QPOn()
    {
        quitPointer.SetActive(true);
    }

    public void QPOff()
    {
        quitPointer.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("HarryHotel", LoadSceneMode.Single);
    }
}