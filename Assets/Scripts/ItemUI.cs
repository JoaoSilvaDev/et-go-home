﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image[] icons;
    public Inventory inventory;

    private void Start()
    {
        inventory.onAddItem += OnItemCollected;
    }

    public void OnItemCollected(int id)
    {
        Color col = icons[id].color;
        col.a = 1;
        icons[id].color = col;
    }
}