using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI_Controller : MonoBehaviour
{
    public GameObject player;

    //Stemina
    public Image stemina;
    float stemina_amount = 1;
    public float stemina_dec; //스테미나 감소 속도
    public float stemina_inc; //스테미나 회복 속도
    bool fullstemina;

    //HealthPoint
    public Image HP;
    public float HP_amount;
    float fullHP;
    public float HP_dec; //몬스터와 충돌시

    //Mana
    public Image Mana;
    public static float Mana_amount = 100;
    public float mana_inc; //마나 회복 속도
    float fullMana;

    //shield
    public static float ori_hp;

    public static bool shieldON;
    float time;


    void Start()
    {
        shieldON = false;
        fullstemina = true;
        fullHP = HP_amount;
        fullMana = Mana_amount;
        time = 0;
    }

    void FixedUpdate()
    {
        if (Player_Controller.isdeath == false)
        {
            Stemina();
            HealthPoint();
            ManaPoint();
            shield();
            
            if (HP_amount <= 0)
            {
                Player_Controller.isdeath = true;
                Scene_Manager.isdeath = true;
                player.GetComponent<Player_Controller>().Death();
                HealthPoint();
            }
        }
    }

    void Stemina()
    {
        stemina.fillAmount = stemina_amount;

        if (Player_Controller.isruning)
        {
            stemina_amount -= stemina_dec;
            fullstemina = false;
            if (stemina_amount <= 0.01f)
            {
                Player_Controller.canrun = false;
                stemina.color = new Color(1, 1, 1, 0.5f);
            }
        }
        else if (Player_Controller.isruning == false && fullstemina == false)
        {
            stemina_amount += stemina_inc;
            if (stemina_amount >= 1)
            {
                fullstemina = true;
                stemina.color = new Color(1, 1, 1, 1f);
                Player_Controller.canrun = true;
            }
        }
    }

    void HealthPoint()
    {
        HP.fillAmount = HP_amount / fullHP;
    }

    void ManaPoint()
    {
        Mana.fillAmount = Mana_amount / fullMana;
        if(Mana_amount < fullMana)
        {
            Mana_amount += mana_inc;
        }
    }

    void shield()
    {
        if (shieldON)
        {
            time += Time.deltaTime;
            if (time > 8)
            {
                shieldON = false;
                time = 0;
            }
            HP_amount = ori_hp;
        }
    }

    public void col_dam()
    {
        if (shieldON == false)
            HP_amount -= HP_dec;
    }


    public void HealHP(float amount)
    {
        HP_amount += amount;
        if (HP_amount > fullHP)
            HP_amount = fullHP;
    }

    public void HealMP(float amount)
    {
        Mana_amount += amount;
        if (Mana_amount > fullMana)
            Mana_amount = fullMana;
    }

}
