using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightManager : MonoBehaviour
{
    public GameObject[] VillageLights;
    public GameObject[] MountainLights;
    // Start is called before the first frame update
    private void Start()
    {

        for (int i = 0; i < MountainLights.Length; i++)
        {

            MountainLights[i].SetActive(false);
        }

    }
    public void setLight()
    {
        for(int i=0; i<VillageLights.Length; i++)
        {
            VillageLights[i].SetActive(false);
        }

        for(int i=0; i<MountainLights.Length; i++)
        {
            MountainLights[i].SetActive(true);
        }
    }
}
