using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject options;
    public GameObject howtoplay;
    public GameObject Credits;
    public GameObject Credit1;
    public GameObject Credit2;
    public GameObject Credit1_1;
    public GameObject Credit2_2;
    public Slider music;
    public Slider sound;
    bool option_visible;
     
    public bool ingame; //인게임씬에서 작동하는 버튼인지
    public Image PausePlay;
    public Sprite Pause;
    public Sprite Play;
    AudioSource AD;

    private void Start()
    {
        Time.timeScale = 1.0f;
        options.SetActive(false);
        option_visible = false;
        AD = GetComponent<AudioSource>();
    }

    public void StartButton()
    {
        SceneManager.LoadScene("InGame");
        AD.Play();
        
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        AD.Play();
    }

    public void ShowHowToPlay()
    {
        howtoplay.SetActive(true);
        options.SetActive(false);
        AD.Play();
    }

    public void OFFhowtoplay()
    {
        howtoplay.SetActive(false);
        options.SetActive(true);
        AD.Play();
    }

    public void ShowCredits()
    {
        Credits.SetActive(true);
        options.SetActive(false);
        AD.Play();
    }

    public void OFFCredits()
    {
        Credits.SetActive(false);
        options.SetActive(true);
        AD.Play();
    }

    public void NextCredits1()
    {
        Credit1.SetActive(true);
        Credit1_1.SetActive(true);
        Credit2.SetActive(false);
        Credit2_2.SetActive(false);
    }
    public void NextCredits2()
    {
        Credit2.SetActive(true);
        Credit2_2.SetActive(true);
        Credit1.SetActive(false);
        Credit1_1.SetActive(false);
    }

    public void Option()
    {
        if (option_visible)
        {
            Time.timeScale = 1f;
            option_visible = false;
            options.SetActive(false);
            if (ingame)
            {
                PausePlay.sprite = Pause;
            }
        }
        else
        {
            Time.timeScale = 0f;
            option_visible = true;
            options.SetActive(true);
            if (ingame)
            {
                PausePlay.sprite = Play;
            }
        }
        AD.Play();
    }

    public void Exit()
    {
        Application.Quit();
    }


}
