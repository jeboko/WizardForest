﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public GameObject item;
    public Item(Item item)
    {
        this.item = item.item;
    }
}