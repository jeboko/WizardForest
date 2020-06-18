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
    bool day_night;
    public Text Days;
    public static int day_count;

    public float day_time;
    public float night_time;
    float time;
    
    public static bool isdeath;
    float death_time;
    public GameObject Death_Option;

    void Start()
    {
        day_night = true;
        day_count = 1;
        isdeath = false;
        death_time = 0;
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
                Days.text = "D - " + day_count.ToString();
            }
        }

        if (isdeath)
        {
            print(death_time);
            death_time += Time.deltaTime;
            if(death_time > 3f)
            {
                Death_Option.SetActive(true);
                Time.timeScale = 0;
                isdeath = false;
            }
        }
    }
}
