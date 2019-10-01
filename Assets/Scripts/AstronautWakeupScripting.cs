using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AstronautWakeupScripting : MonoBehaviour
{
    public float minDistance;
    public GameObject portalVFX;
    private bool wokeup = false;

    private Animator animator;
    private Transform cam;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cam = GameObject.FindObjectOfType<Camera>().transform;
    }

    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, cam.position));
        if (Vector3.Distance(transform.position, cam.position) < minDistance && !wokeup)
        {
            wokeup = true;

            animator.SetBool("getup", true);
            portalVFX.SetActive(true);

            StartCoroutine(WaitBeforeNextScene());
        }
    }

    IEnumerator WaitBeforeNextScene()
    {
        Debug.Log("Started wai");
        yield return new WaitForSeconds(4);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("03");
    }
}
