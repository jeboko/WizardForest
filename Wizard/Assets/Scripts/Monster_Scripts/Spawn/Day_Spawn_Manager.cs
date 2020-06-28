using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Spawn_Manager : MonoBehaviour
{
    Spawn_System spawn_manager;
    Scene_Manager scene_manager;

    void Start()
    {
        spawn_manager = gameObject.GetComponent<Spawn_System>();
        scene_manager = GameObject.Find("GameManager").GetComponent<Scene_Manager>();
        init_spawn_system();
    }

    private void OnEnable()
    {
        update_spawn_system();
    }

    void init_spawn_system()
    {
        spawn_manager.deck[0].weight = 10;
        spawn_manager.deck[1].weight = 5;
        spawn_manager.deck[2].weight = 5;
        spawn_manager.deck[3].weight = 0;
        spawn_manager.deck[4].weight = 0;
    }

    void update_spawn_system()
    {
        if(spawn_manager.delay_min >= 1.5f)
        {
            spawn_manager.delay_min -= 0.1f;
            spawn_manager.delay_max -= 0.1f;
        }

        if (scene_manager.day_count <= 3)
        {
                spawn_manager.deck[0].weight *= 1.3f;
                spawn_manager.deck[1].weight *= 1.5f;
                spawn_manager.deck[2].weight *= 1.5f;
        }

        if (scene_manager.day_count > 3 &&scene_manager.day_count <= 6)
        {
            spawn_manager.deck[0].weight *= 0.5f;
            spawn_manager.deck[1].weight *= 1.0f;
            spawn_manager.deck[2].weight *= 1.0f;
            spawn_manager.deck[3].weight += 4f;
            spawn_manager.deck[4].weight += 2f;
        }

        if (scene_manager.day_count > 6 && scene_manager.day_count <= 9)
        {
            spawn_manager.deck[0].weight *= 0.2f;
            spawn_manager.deck[1].weight *= 1.1f;
            spawn_manager.deck[2].weight *= 0.5f;
            spawn_manager.deck[3].weight *= 1.2f;
            spawn_manager.deck[4].weight *= 1.2f;
        }

        if (scene_manager.day_count > 9)
        {
            spawn_manager.deck[0].weight = 0f;
            spawn_manager.deck[1].weight = 10;
            spawn_manager.deck[2].weight = 0f;
            spawn_manager.deck[3].weight = 12f;
            spawn_manager.deck[4].weight = 8f;
        }
    }
}
