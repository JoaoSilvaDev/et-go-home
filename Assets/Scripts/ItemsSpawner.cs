using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using System.Collections.Generic;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    float _spawnScale = 100f;

    [SerializeField]
    Item[] _itemsToInstantiate;

    List<Item> _spawnedItems;

    void Start()
    {
        _spawnedItems = new List<Item>();

        for (int i = 0; i < _itemsToInstantiate.Length; i++)
        {
            var item = Instantiate(_itemsToInstantiate[i]);

            item.transform.localPosition = _map.GeoToWorldPosition(
                new Vector2d(item.latitude, item.longitude), true);

            item.transform.localScale = Vector3.one * _spawnScale;
            _spawnedItems.Add(item);
        }
    }

    private void Update()
    {
        for (int i = 0; i < _spawnedItems.Count; i++)
        {
            _spawnedItems[i].transform.localPosition = _map.GeoToWorldPosition(
                new Vector2d(_spawnedItems[i].latitude, _spawnedItems[i].longitude), true);

            _spawnedItems[i].transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
        }
    }
}

