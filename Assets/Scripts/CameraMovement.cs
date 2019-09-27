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

    [SerializeField] private float speedToStartRotationOnPinch = 50;

    public float currentZoom { get => _currentZoom; set => _currentZoom = Mathf.Clamp01(value); }
    private float _currentZoom = 0;

    private float previousTouchDistance;
    private Vector3 initialTouchDirection;
    private Vector3 previousTouchDirection;
    private float previousTouchesScreenRelativeAngle;

    private float currentYawAngle;

    private bool rotatingOnPinch = false;

    private void Start()
    {
        currentYawAngle = transform.eulerAngles.y;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            if (Input.touches[1].phase == TouchPhase.Began)
            {
                previousTouchDistance = GetTouchesDistance();
                previousTouchesScreenRelativeAngle = GetTouchesScreenRelativeAngle();
            }
            else
            {
                //zoom camera
                var newDistance = GetTouchesDistance();
                var deltaDistance = newDistance - previousTouchDistance;
                previousTouchDistance = newDistance;
                currentZoom += deltaDistance * zoomSpeed * Time.deltaTime;

                //rotate camera
                var newAngle = GetTouchesScreenRelativeAngle();
                var deltaAngle = newAngle - previousTouchesScreenRelativeAngle;
                previousTouchesScreenRelativeAngle = newAngle;


                if (Input.touches[1].phase == TouchPhase.Ended)
                {
                    rotatingOnPinch = false;
                }
                else
                {
                    if (rotatingOnPinch)
                        currentYawAngle += deltaAngle;
                    else
                    {
                        var rotationSpeed = Mathf.Abs(deltaAngle / Time.deltaTime);
                        print(rotationSpeed);
                        if (rotationSpeed >= speedToStartRotationOnPinch)
                            rotatingOnPinch = true;
                    }
                }

            }
        }
#if UNITY_ANDROID
        else if (Input.touchCount == 1)
#elif UNTIY_EDITOR
        else if (Input.GetMouseButton(0))
#endif
        {

            //if (Input.touches[0].phase == TouchPhase.Began)
            if (Input.GetMouseButtonDown(0))
            {
                initialTouchDirection = GetTouchDirectionFromCenter();
            }
            //else if (Input.touches[0].phase == TouchPhase.Moved)
            else
            {
                var newDirection = GetTouchDirectionFromCenter();
                var angle = Vector3.SignedAngle(initialTouchDirection, newDirection, Vector3.up);
                currentYawAngle -= angle;
            }
        }

        UpdatePitchAngle();
        LookAtTarget();
        UpdateYawAngle();
    }

    private Vector3 GetTouchDirectionFromCenter()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
#if UNITY_ANDROID
        Ray ray = camera.ScreenPointToRay(Input.touches[0].position);
#elif UNTIY_EDITOR
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
#endif
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
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, currentYawAngle, 0), Time.deltaTime * zoomSmoothSpeed);
    }

    private float GetTouchesDistance() => (Input.touches[0].position - Input.touches[1].position).magnitude;

    private float GetTouchesScreenRelativeAngle()
    {
        var direction = (Input.touches[0].position - Input.touches[1].position).normalized;
        return Vector2.SignedAngle(Vector2.up, direction);
    }

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
