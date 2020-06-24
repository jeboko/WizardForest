using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseUI : MonoBehaviour
{
    private bool pauseOn = false;
    private bool buildOn = false;
    private bool invenOn = false;


    private GameObject buildPanel;
    private GameObject invenpanel;

    private void Awake()
    {
    

        buildPanel = GameObject.Find("Canvas").transform.Find("buildScreen").gameObject;

        invenpanel = GameObject.Find("Canvas").transform.Find("inventory").gameObject;
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
