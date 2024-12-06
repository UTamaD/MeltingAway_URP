using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePoint : MonoBehaviour
{

    
    public GameObject savePointManger;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "player" || other.tag == "Player")
        {
            savePointManger.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }



}
