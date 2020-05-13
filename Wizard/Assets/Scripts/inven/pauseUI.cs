using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseUI : MonoBehaviour
{
    private bool pauseOn = false;
    private GameObject ingamePanel;
    private GameObject pausePanel;

    private void Awake()
    {
        ingamePanel = GameObject.Find("Canvas").transform.FindChild("pauseButton").gameObject;

        pausePanel = GameObject.Find("Canvas").transform.FindChild("pauseScreen").gameObject;
    }

    public void activePause()
    {
        if (!pauseOn)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
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

}
