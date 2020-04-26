using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI_Controller : MonoBehaviour
{
    //Stemina
    public Image stemina;
    float stemina_amount = 1;
    public float stemina_dec; //스테미나 감소 속도
    public float stemina_inc; //스테미나 회복 속도
    bool fullstemina;

    void Start()
    {
        fullstemina = true;
    }

    void FixedUpdate()
    {
        if (Player_Controller.isdeath == false)
        {
            Stemina();
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
}
