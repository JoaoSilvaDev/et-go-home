using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private Transform topAnchor;
    [SerializeField] private Transform bottomAnchor;

    [SerializeField] private bool lookAtTarget = true;
    [SerializeField] private float lookAtHeightOffset = 0;

    [SerializeField] private float zoomSpeed = 0.5f;
    [SerializeField] private float zoomSmoothSpeed = 10f;

    public float currentZoom { get => _currentZoom; set => _currentZoom = Mathf.Clamp01(value); }
    private float _currentZoom = 0;

    private float previousTouchDistance;
    private Vector3 previousTouchDirection;

    private float initialCameraAngle;
    private float currentCameraAngle;

    private void Start()
    {
        initialCameraAngle = transform.eulerAngles.y;
        currentCameraAngle = initialCameraAngle;
    }

    private void Update()
    {
        if(Input.touchCount == 2)
        {
            if (Input.touches[1].phase == TouchPhase.Began)
            {
                previousTouchDistance = GetTouchesDistance();
            }
            else
            {
                var newDistance = GetTouchesDistance();
                var deltaDistance = newDistance - previousTouchDistance;
                previousTouchDistance = newDistance;
                currentZoom += deltaDistance * zoomSpeed * Time.deltaTime;
            }
        }
        else if(Input.touchCount == 1)
        {
            if(Input.touches[0].phase == TouchPhase.Moved)
            {
                var newDirection = GetTouchDirectionFromCenter();
                var angle = Vector3.SignedAngle(transform.forward, newDirection, Vector3.up);
                currentCameraAngle = initialCameraAngle - angle;
            }
        }

        UpdatePitchAngle();
        LookAtTarget();
        UpdateYawAngle();
    }

    private Vector3 GetTouchDirectionFromCenter()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = camera.ScreenPointToRay(Input.touches[0].position);
        float enter;
        if (plane.Raycast(ray, out enter))
        {
            var hitPoint = ray.GetPoint(enter);
            this.hitpoint = hitPoint;
            return (transform.position - hitPoint).normalized;
        }

        return Vector3.zero;
    }

    private void UpdateYawAngle()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,currentCameraAngle,0), Time.deltaTime * zoomSmoothSpeed);
    }

    private float GetTouchesDistance() => (Input.touches[0].position - Input.touches[1].position).magnitude;

    private void LookAtTarget()
    {
        if (lookAtTarget)
            camera.transform.LookAt(transform.position + Vector3.up * lookAtHeightOffset);
    }

    private void UpdatePitchAngle()
    {
        Vector3 topRelCenter = topAnchor.position - transform.position;
        Vector3 bottomRelCenter = bottomAnchor.position - transform.position;

        var slerp = Vector3.Slerp(topRelCenter, bottomRelCenter, currentZoom);

        var finalPos = slerp + transform.position;

        camera.transform.position = Vector3.Lerp(camera.transform.position, finalPos, Time.deltaTime * zoomSmoothSpeed);
    }

    Vector3 hitpoint;
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hitpoint, 0.5f);
    }
}
