using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSktbox : MonoBehaviour
{
    public Material daySkyMaterial;
    public Material nightSkyMaterial;
    public float transitionSpeed = 0.5f;

    private Material skyboxMaterial;
    private float blendFactor = 0f;

    private void Start()
    {
        skyboxMaterial = RenderSettings.skybox;
    }

    private void Update()
    {
        blendFactor = Mathf.PingPong(Time.time * transitionSpeed, 1f);
        skyboxMaterial.Lerp(daySkyMaterial, nightSkyMaterial, blendFactor);
    }
}
