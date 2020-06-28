using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obj_Ability : MonoBehaviour
{
    public int Hp = 10;

    private Canvas uiCanvas;
    private Image hpBarImage;

    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0.0f, 2.0f, 0);

    private float initHp;

    private void Awake()
    {
        initHp = (float)Hp;
        uiCanvas = GameObject.Find("UI_Canvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate<GameObject>(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpbar = hpBar.GetComponent<Monster_HP_Bar>();
        _hpbar.targetTr = this.gameObject.transform;
        _hpbar.offset = hpBarOffset;
    }

    // Update is called once per frame
    void Update()
    {
        hpBarImage.fillAmount = Hp / initHp;

        if (Hp <= 0)
        {
            Destroy(this.gameObject);
            gameObject.GetComponent<Boom>().boom_eff();
            
        }


    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Hp--;

            if (gameObject.tag == "baricate")
            {
                other.transform.Translate(Vector3.forward * -0.5f);
            }
            if (gameObject.tag == "baricate2")
            {
                other.transform.Translate(Vector3.forward * -0.5f);
            }

            if (gameObject.tag == "baricate3")
            {
                other.transform.Translate(Vector3.forward * -0.5f);
            }

            if (gameObject.tag == "poison_trap")
            {
                other.gameObject.GetComponent<Mob_controller>().Hp -= 1.0f;
            }
            if (gameObject.tag == "slow_trap")
            {
                other.gameObject.GetComponent<Mob_controller>().Speed = 0.5f;
            }
            if (gameObject.tag == "fire_barrel")
            {
                other.gameObject.GetComponent<Mob_controller>().Hp -= 50.0f;
            }
        }

        if (other.gameObject.tag == "Mob_Atk" && (gameObject.tag == "baricate" || gameObject.tag == "baricate2" || gameObject.tag == "baricate3"))
        {
            Destroy(other.gameObject);
        }

    }


}
