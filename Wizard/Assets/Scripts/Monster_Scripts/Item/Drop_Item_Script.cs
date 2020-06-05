using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Item_Script : MonoBehaviour
{
    public List<Item> item_object = new List<Item>();
    public int i_num;
    public GameObject temp;

    private bool isdorp;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        i_num = 0;
        isdorp = true;
    }

    // Update is called once per frame
    void Update()
    {
        drop_item();
    }


    void drop_item()
    {
        i_num = (int)Random.Range(0f, i_num);
        temp = item_object[i_num].item;
        if (isdorp)
        {
           if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.dead") &&
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
            {
                Instantiate(temp, gameObject.transform.position, Quaternion.identity);
                isdorp = false;
            }
        }
    }
}
