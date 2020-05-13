using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Short_Range : MonoBehaviour
{
    public GameObject atk_range;

    private float time;
    private Nomal_Mob_Animator can_atk;

    // Start is called before the first frame update
    void Start()
    {
        atk_range.SetActive(false);
        can_atk = gameObject.GetComponent<Nomal_Mob_Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (can_atk.short_atk)
        {
            atk_range.SetActive(true);
        }
        if (!can_atk.short_atk)
        {
            atk_range.SetActive(false);
        }
    }
}
