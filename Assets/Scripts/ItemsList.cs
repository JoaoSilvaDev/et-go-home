using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items List", menuName = "Items List")]
public class ItemsList : ScriptableObject
{
    public Item[] Items { get => items;}
    [SerializeField] private Item[] items;
}
