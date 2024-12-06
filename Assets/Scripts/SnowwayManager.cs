using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowwayManager : MonoBehaviour
{

    public int maxTime = 50;
    private int timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        timeCounter += 1;
        if (other.tag == "Player")
        {
            //Debug.Log("triigerStay");
            if (timeCounter> maxTime && (other.gameObject.GetComponentInParent<PlayerManager>().scale > 0.5f))
            {
                other.gameObject.GetComponentInParent<PlayerManager>().scale *= 0.99f;
                timeCounter = 0;
                
            }
            

        }
    }
}
