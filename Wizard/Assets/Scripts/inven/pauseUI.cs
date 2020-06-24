using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseUI : MonoBehaviour
{
    private bool pauseOn = false;
    private bool buildOn = false;
    private bool invenOn = false;


    private GameObject ingamePanel;
    private GameObject pausePanel;
    private GameObject buildPanel;
    private GameObject invenpanel;

    private void Awake()
    {
        ingamePanel = GameObject.Find("Canvas").transform.Find("pauseButton").gameObject;

        pausePanel = GameObject.Find("Canvas").transform.Find("pauseScreen").gameObject;

        buildPanel = GameObject.Find("Canvas").transform.Find("buildScreen").gameObject;

        invenpanel = GameObject.Find("Canvas").transform.Find("inventory").gameObject;
    }

    public void activePause()
    {
        if (!pauseOn)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            buildPanel.SetActive(false);
            ingamePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
            ingamePanel.SetActive(true);
        }
        

        pauseOn = !pauseOn;
        // 불값 반전
    }
    public void RetryButton()
    {
        Debug.Log("게임 재시작");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("invenScene");
    }

    public void QuitButton()
    {
        Debug.Log("게임종료");
        Application.Quit();

    }

    public void activebuild()
    {
        if (!buildOn)
        {
            
            buildPanel.SetActive(true);
        }
        else
        {

            buildPanel.SetActive(false);
        }

        buildOn = !buildOn;
    }

    public void activeinven()
    {
        if (!invenOn)
        {

            invenpanel.SetActive(true);
        }
        else
        {

            invenpanel.SetActive(false);
        }

        invenOn = !invenOn;
    }

}
