using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopInput : MonoBehaviour
{
    public GameObject _Player;
    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        _Player.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
        _Player.GetComponent<AudioSource>().Stop();
    }

    void OnDisable()
    {
        _Player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
    }
}
