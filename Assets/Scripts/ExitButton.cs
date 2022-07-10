using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitButton : MonoBehaviour
{
    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnClickBackToStartPage()
    {
        SceneManager.LoadScene("Dummy");
    }
}
