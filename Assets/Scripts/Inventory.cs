using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private static List<int> _items;

    public static Action<int> onAddItem;

    public static void AddItem(Item item)
    {
        if (item == null || item.id < 0)
        {
            Debug.LogWarning("There is no item selected");
            return;
        }

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

    public static void AddItem(int id)
    {
        if (id < 0)
        {
            Debug.LogWarning("There is no item selected");
            return;
        }

        if (_items == null)
            _items = new List<int>();

        if (!_items.Contains(id))
        {
            _items.Add(id);
            if (onAddItem != null)
                onAddItem.Invoke(id);
        }
        else
            Debug.LogWarning("The inventory already contains this item - " + id);
    }

    public static int[] GetItems() => _items.ToArray();
}
