using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMaterialsOnTouch : MonoBehaviour
{
    public Material alternativenMaterial;
    private Material startingMaterial;
        
    private MeshRenderer meshRenderer;
    private bool alternativeMat = false;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        startingMaterial = meshRenderer.material;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            SwitchMaterial();
    }

    void SwitchMaterial()
    {
        alternativeMat = !alternativeMat;

        if (alternativeMat)
            meshRenderer.material = alternativenMaterial;
        else
            meshRenderer.material = startingMaterial;
    }
}
