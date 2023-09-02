using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunctions : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Environment");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
