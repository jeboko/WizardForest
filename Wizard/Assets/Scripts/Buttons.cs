using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject options;
    bool option_visible;

    private void Start()
    {
        options.SetActive(false);
        option_visible = false;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void Option()
    {
        if (option_visible)
        {
            option_visible = false;
            options.SetActive(false);
        }
        else
        {
            option_visible = true;
            options.SetActive(true);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
