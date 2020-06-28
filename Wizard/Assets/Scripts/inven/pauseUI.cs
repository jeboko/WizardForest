using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseUI : MonoBehaviour
{
    public bool buildOn = false;
    public bool invenOn = false;

    public bool farming_state = false;

    public GameObject buildPanel;
    public GameObject invenpanel;
    AudioSource AD;

    private void Awake()
    {
        AD = GetComponent<AudioSource>();

        buildPanel = GameObject.Find("Canvas").transform.Find("buildScreen").gameObject;

        invenpanel = GameObject.Find("Canvas").transform.Find("inventory").gameObject;
    }

    public void activebuild()
    {
        if (GameObject.Find("item_List_Bt").GetComponent<pauseUI>().invenOn == true)
        {
            GameObject.Find("item_List_Bt").GetComponent<pauseUI>().activeinven();

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

        else
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

    }

    public void activeinven()
    {
        if (GameObject.Find("build_List_Bt").GetComponent<pauseUI>().buildOn == true)
        {
            GameObject.Find("build_List_Bt").GetComponent<pauseUI>().activebuild();

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

        else
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

    public void farming()
    {
        farming_state = true;
        AD.Play();
    }

    private void Update()
    {
        if (farming_state == true)
        {
            StartCoroutine(WaitForIt());
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.0f);
        farming_state = false;
    }

}