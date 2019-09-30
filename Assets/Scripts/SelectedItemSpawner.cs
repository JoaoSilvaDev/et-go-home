using UnityEngine;

public class SelectedItemSpawner : MonoBehaviour
{
    [SerializeField] private ItemsList itemsList;
    [SerializeField] private float scale = 0.1f;

    private void Start()
    {
        var selected = ItemCollector.SelectedItem;

        if (selected == -1)
        {
            Debug.LogError("there is no selected item");
            return;
        }

        if (itemsList.Items.Length <= selected)
        {
            Debug.LogError("the items list does not contain the selected item");
            return;
        }

        //ItemCollector.ConsumeSelectedItem();
        Instantiate(itemsList.Items[selected], transform.position, Quaternion.identity);
    }
}
