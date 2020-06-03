using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public static float MusicVolume;
    public static float SoundVolume;
    public GameObject options;
    public GameObject howtoplay;
    public Slider music;
    public Slider sound;
    bool option_visible;

    public bool ingame; //인게임씬에서 작동하는 버튼인지
    public Image PausePlay;
    public Sprite Pause;
    public Sprite Play;

    private void Start()
    {
        options.SetActive(false);
        option_visible = false;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowHowToPlay()
    {
        howtoplay.SetActive(true);
        options.SetActive(false);
    }

    public void OFFhowtoplay()
    {
        howtoplay.SetActive(false);
        options.SetActive(true);
    }

    public void Option()
    {
        if (option_visible)
        {
            SaveOption();
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
            LoadOption();
            Time.timeScale = 0f;
            option_visible = true;
            options.SetActive(true);
            if (ingame)
            {
                PausePlay.sprite = Play;
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    void SaveOption()
    {
        music.GetComponent<Slider>().value = MusicVolume;
        sound.GetComponent<Slider>().value = SoundVolume;
    }
    void LoadOption()
    {
        MusicVolume = music.GetComponent<Slider>().value;
        SoundVolume = sound.GetComponent<Slider>().value;
    }
}
