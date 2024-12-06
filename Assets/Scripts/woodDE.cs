using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class woodDE : MonoBehaviour
{

    public AudioClip woodBroken;
    public AudioSource myAudio;

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Wood")
        {

            AudioSource.PlayClipAtPoint(woodBroken, gameObject.transform.position, 0.4f);
            Destroy(other);
            
        }
    }
}
