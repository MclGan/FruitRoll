using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dummy : MonoBehaviour
{
    const string userAgreedKey = "User Agreed";
    [SerializeField] private GameObject switchCircle;
    [SerializeField] private GameObject switchButtonBG;
    [SerializeField] private Button startGame;
    public bool userAgreed = false;

    void Start()
    {
        var userAgreedString = PlayerPrefs.GetString(userAgreedKey);
        if (!string.IsNullOrWhiteSpace(userAgreedString))
        {
            userAgreed = Convert.ToBoolean(userAgreedString);
        }

        Vector2 pos = switchCircle.transform.position;
        if (userAgreed)
        {
            startGame.interactable = true;
            pos.x += 0.25f;
            switchCircle.transform.position = pos;
        }
        else
            startGame.interactable = false;

        switchButtonBG.GetComponent<Image>().color = userAgreed ? Color.green : Color.grey;
    }

    public void OnClickSwitchButton()
    {
        Vector2 pos = switchCircle.transform.position;
        

        if (userAgreed)
        {
            startGame.interactable = false;
            pos.x -= 0.25f;
        }
        else
        {
            startGame.interactable = true;
            pos.x += 0.25f;
        }    
            

        switchCircle.transform.position = pos;

        switchButtonBG.GetComponent<Image>().color = userAgreed ? Color.grey : Color.green;

        userAgreed = !userAgreed;

        PlayerPrefs.SetString(userAgreedKey, userAgreed.ToString());
    }

    public void OnClickPolicyLink()
    {
        SceneManager.LoadScene("PolicyPage");
    }

    public void OnClickStart()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene("WebView");
        }
        else
        {
            SceneManager.LoadScene("GamePage");
        }
        
    }

}
