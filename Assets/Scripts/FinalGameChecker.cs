using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalGameChecker : MonoBehaviour
{
    [SerializeField] private ItemsList itemsList;
    [SerializeField] private UnityEvent onCollectAllItems;

    private void OnEnable()
    {
        if(itemsList.Items.Length == Inventory.ItemsCount)
        {
            onCollectAllItems.Invoke();
        }
    }
}
