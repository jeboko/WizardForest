using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{
    public List<Skills> skill_list = new List<Skills>();
    public GameObject player;

    float time;

    public GameObject nomal_attack;
    public float normal_cooltime;

    Skills skill;

    void Start()
    {
        time = normal_cooltime;
    }

    void FixedUpdate()
    {
        if(time < normal_cooltime)
        {
            time += Time.deltaTime;
        }
    }

    public void Normal_shot()
    {
        if(time >= normal_cooltime)
        {
            time = 0;
            Instantiate(nomal_attack, transform.position, transform.rotation);
        }
    }

    public void Skill()
    {
        if(Player_UI_Controller.Mana_amount > skill.skill_mana)
        {
            Player_UI_Controller.Mana_amount -= skill.skill_mana;
            Player_Controller.skill_time = skill.skill_time;
            Player_Controller.skill_usetime = skill.skill_usetime;
            player.GetComponent<Player_Controller>().Skill_anim(skill.skill_anim);
        }
    }

    public void Use_Skill()
    {
        Instantiate(skill.skill_obj, transform.position, transform.rotation);
    }

    public void Load_Skill(int skill_num)
    {
        skill = skill_list[skill_num];
    }
}

[System.Serializable]
public class Skills
{
    public GameObject skill_obj;
    public float skill_mana;
    public int skill_anim;
    public float skill_time;
    public float skill_usetime;

    public Skills (Skills skill)
    {
        this.skill_obj = skill.skill_obj;
        this.skill_mana = skill.skill_mana;
        this.skill_obj = skill.skill_obj;
        this.skill_time = skill.skill_usetime;
    }
}
