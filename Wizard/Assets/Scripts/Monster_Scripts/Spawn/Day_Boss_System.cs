using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Boss_System : MonoBehaviour
{
    Mob_Manager_Scripts info_manager;
    Scene_Manager scene_manager;
    // Start is called before the first frame update
    void Start()
    {
        info_manager = GameObject.Find("Monster_Manager").GetComponent<Mob_Manager_Scripts>();
        scene_manager = GameObject.Find("GameManager").GetComponent<Scene_Manager>();
    }

    
    private void OnEnable()
    {
        info_manager.deck[5].Hp += 20;
    }
}
