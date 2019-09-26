using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private static List<int> _items;

    public static Action<int> onAddItem;

    public void AddItem(Item item)
    {
        if (_items == null)
            _items = new List<int>();

        if (!_items.Contains(item.id))
        {
            _items.Add(item.id);
            if (onAddItem != null)
                onAddItem.Invoke(item.id);
        }
        else
            Debug.LogWarning("The inventory already contains this item - " + item.title);
    }

    public int[] GetItems() => _items.ToArray();
}
