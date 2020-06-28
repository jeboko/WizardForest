using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{
    Player_UI_Controller player_hp_controller;
    public GameObject day_image;
    public GameObject night_image;
    public GameObject dayLight;
    public GameObject nightLight;
    public static bool day_night;
    public bool is_day;
    public Text Days;
    public int day_count;

    public float day_time;
    public float night_time;
    [HideInInspector] public float time;
   
    
    public static bool isdeath;
    float death_time;
    public GameObject Death_Option;

    public GameObject spwaner;
    public GameObject boss_spawner;

    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;
    public GameObject UI5;

    void Start()
    {
        player_hp_controller = GameObject.Find("Player_UI").GetComponent<Player_UI_Controller>();
        day_night = true;
        day_count = 1;
        isdeath = false;
        death_time = 0;
        is_day = true;
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
                UI1.SetActive(false);
                UI2.SetActive(false);
                UI3.SetActive(false);
                UI4.SetActive(false);
                UI5.SetActive(false);
            }
            is_day = true;
            spwaner.SetActive(false);
            boss_spawner.SetActive(false);
            player_hp_controller.HP_amount = player_hp_controller.fullHP;
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
                UI1.SetActive(true);
                UI2.SetActive(true);
                UI3.SetActive(true);
            }
            is_day = false;
            spwaner.SetActive(true);
            boss_spawner.SetActive(true);
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
