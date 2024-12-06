using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intothewater : MonoBehaviour
{

    public GameObject myAudio;
    private float _melting =0.95f;
    public float meltingMul = 4.0f;
    public GameObject cameraEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            _melting = other.GetComponent<PlayerManager>().melting;
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(myAudio != null && other.tag == "Player")
        {
            myAudio.SetActive(true);
            other.GetComponent<PlayerManager>().melting = _melting * 2.0f;

            if(other.GetComponent<PlayerManager>().size < 0.3)
            {
                other.GetComponent<PlayerManager>().melting = _melting * 2.0f * meltingMul;
            }

            if (cameraEffect != null)
            {
                cameraEffect.SetActive(true);
            }
        }



        
        

        
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (myAudio != null && other.tag == "Player")
        {
            myAudio.SetActive(false);
            other.GetComponent<PlayerManager>().melting = _melting;

            if (cameraEffect != null)
            {
                cameraEffect.SetActive(false);
            }
        }


    }
}
