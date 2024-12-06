using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridgeOpen : MonoBehaviour
{
    public GameObject myTimelineStart;

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            

            if(myTimelineStart!=null )
            {
                myTimelineStart.SetActive(true);
            }


        }

    }
}
