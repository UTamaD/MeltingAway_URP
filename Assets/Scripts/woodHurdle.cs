using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class woodHurdle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            //StartCoroutine(Vibrate());

            other.gameObject.GetComponentInParent<PlayerManager>().size -=0.001f;
            other.GetComponent<PlayerManager>().Vib();
            // StartCoroutine(stay());
            Destroy(gameObject);


        }

    }
}


    
