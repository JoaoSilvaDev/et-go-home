using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectPlacementOnFindPlane : MonoBehaviour
{

    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject objectToInstantiate;
    [SerializeField] private UnityEvent onSuitablePlaneFound;

    private bool _found;

    private void Start()
    {
        planeManager.planesChanged += OnChangePlanes;
    }

    private void OnDestroy()
    {
        if(planeManager)
            planeManager.planesChanged -= OnChangePlanes;
    }

    private void OnChangePlanes(ARPlanesChangedEventArgs args)
    {
        if (_found)
            return;

        for (int i = 0; i < args.added.Count; i++)
        {
            if (IsPlaneSuitable(args.added[i]))
            {
                OnSuitablePlaneFound(args.added[i]);
                return;
            }
        }

        for (int i = 0; i < args.updated.Count; i++)
        {
            if (IsPlaneSuitable(args.updated[i]))
            {
                OnSuitablePlaneFound(args.updated[i]);
                return;
            }
        }
    }

    private bool IsPlaneSuitable(ARPlane plane)
    {
        var alignment = plane.alignment;
        if (alignment == PlaneAlignment.HorizontalDown || alignment == PlaneAlignment.HorizontalUp)
        {
            return true;
        }


        return false;
    }

    private void OnSuitablePlaneFound(ARPlane plane)
    {
        onSuitablePlaneFound.Invoke();
        if(objectToInstantiate)
            Instantiate(objectToInstantiate, plane.center, Quaternion.identity);
        _found = true;
    }
}
