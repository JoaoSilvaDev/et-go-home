using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectPlacementOnTouch : MonoBehaviour
{

    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private Placeable objectToInstantiate;
    [SerializeField] private new Camera camera;
    [SerializeField] private UnityEvent onPlace;

    private Placeable objectInstance;
    private bool placed;

    private void Update()
    {
        if (placed)
            return;

        if (Input.touchCount < 1)
            return;

        print("input");

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        var hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(ray, hits, TrackableType.PlaneWithinBounds))
        {
            var pose = hits[0].pose;
            PlaceObject(pose);
        }
    }

    private void PlaceObject(Pose pose)
    {
        if (!objectInstance)
        {
            objectInstance = Instantiate(objectToInstantiate, pose.position, Quaternion.identity);

            objectInstance.SetMoving();
        }
        else
        {
            objectInstance.transform.position = pose.position;
            objectInstance.transform.rotation = pose.rotation;

            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                objectInstance.Place();
                placed = true;
            }

        }
    }
}
