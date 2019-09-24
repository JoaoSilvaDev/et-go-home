using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public int id;
    public string title;
    public string location;
    public double latitude;
    public double longitude;

    [SerializeField] private UnityEvent onCollect;

    public void Collect()
    {
        onCollect.Invoke();
    }

#if UNITY_EDITOR
    private bool _firstValidade = true;

    private void OnValidate()
    {
        if (!gameObject.CompareTag("Item"))
        {
            if (_firstValidade)
            {
                UnityEditor.EditorUtility.DisplayDialog(
                    "Tag changed",
                    "Changed this Game Object tag to \"Item\" due to Item script",
                    "ok");

                _firstValidade = false;
            }
            gameObject.tag = "Item";
        }
    }
#endif
}
