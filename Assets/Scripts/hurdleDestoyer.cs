using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdleDestoyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "hurdle")
        {
            Destroy(other);
        }
    }
}
