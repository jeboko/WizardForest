using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Item_Script : MonoBehaviour
{
    public List<Item> item_object = new List<Item>();
    public int i_num;
    public GameObject temp;
    public int drop_range;

    public int isdorp;
    Animator animator;
    private Vector3 itme_position;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isdorp = (int)Random.Range(0f, drop_range);
        i_num = (int)Random.Range(0f, i_num);
    }

    // Update is called once per frame
    void Update()
    {
        itme_position = new Vector3(gameObject.transform.position.x, 1.0f, gameObject.transform.position.z);
        drop_item();
    }


    void drop_item()
    {
        temp = item_object[i_num].item;
        if(temp == null)
        {
            return;
        }
        if(temp != null)
        {
            if (isdorp == 1)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.dead") &&
                     animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
                {
                    Instantiate(temp, itme_position, Quaternion.identity);
                    isdorp = 0;
                }
            }
        }
    }
}
