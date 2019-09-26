using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [Tooltip("Range around character where player can grab items")]
    [SerializeField]
    private float range;

    [SerializeField] private int itemCollectScene;

    public static int SelectedItem { get; private set; } = -1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ClickOnItem();
    }

    void ClickOnItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.CompareTag("Item"))
            {
                var item = hit.transform.GetComponent<Item>();

                if(item != null)
                {
                    if(Vector3.Distance(transform.position, item.transform.position) < range)
                        SelectItem(item);
                }
            }
        }
    }

    private void SelectItem(Item item)
    {
        SelectedItem = item.id;
        SceneManager.LoadScene(itemCollectScene);

        print("Selected item " + item.id);
    }

    public static void CollectItem()
    {
        Inventory.AddItem(SelectedItem);
        print("Collected item " + SelectedItem);
        SelectedItem = -1;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
