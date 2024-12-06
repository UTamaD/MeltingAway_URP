using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.Experimental.Rendering;

public class omURP : MonoBehaviour
{
   
    public UniversalRendererData urpData;


    private void Start()
    {


        
    }

    public void Active()
    {
        ScriptableRendererFeature rendererFeatures = urpData.rendererFeatures[1];
        rendererFeatures.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        ScriptableRendererFeature rendererFeatures = urpData.rendererFeatures[1];
        rendererFeatures.SetActive(false);

    }
    public void DeActive()
    {
        ScriptableRendererFeature rendererFeatures = urpData.rendererFeatures[1];
        rendererFeatures.SetActive(false);
    }
}
