using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMarkerScaler : MonoBehaviour
{
    public bool inRange;

    public Transform marker;
    public Transform player;
    public Transform mesh;
    public ItemCollector collector;

    private void Start()
    {
        player = GameObject.Find("PlayerTarget").transform;
        collector = GameObject.Find("Scripts").GetComponent<ItemCollector>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < collector.range && !inRange)
        {
            inRange = true;
            marker.localScale = new Vector3(0, 0, 0);
            mesh.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Vector3.Distance(transform.position, player.position) > collector.range && inRange)
        {
            inRange = false;
            marker.localScale = new Vector3(1, 1, 1);
            mesh.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
