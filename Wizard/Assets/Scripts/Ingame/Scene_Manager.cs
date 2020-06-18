using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{
    public GameObject day_image;
    public GameObject night_image;
    public GameObject dayLight;
    public GameObject nightLight;

    public GameObject spwaner;

    public bool day_night;
    int day_count;

    public float day_time;
    public float night_time;
    float time;

    void Start()
    {
        day_night = true;
    }

    void FixedUpdate()
    {
        if (day_night)
        {
            time += Time.deltaTime;
            day_image.GetComponent<Image>().fillAmount = 1f - (time / day_time);

            if (time >= day_time)
            {
                day_image.SetActive(false);
                dayLight.SetActive(false);
                night_image.SetActive(true);
                nightLight.SetActive(true);
                day_night = false;
                time = 0;
            }
            spwaner.SetActive(false);
        }

        else
        {
            time += Time.deltaTime;
            night_image.GetComponent<Image>().fillAmount = 1f - (time / night_time);

            if (time >= night_time)
            {
                day_image.SetActive(true);
                dayLight.SetActive(true);
                night_image.SetActive(false);
                nightLight.SetActive(false);
                day_night = true;
                time = 0;
                day_count++;
            }
            spwaner.SetActive(true);
        }
    }
}
