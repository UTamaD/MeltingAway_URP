using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubbleBosting : MonoBehaviour
{
    public GameObject SpeedLine;

    // Start is called before the first frame update
    void Start()
    {
        SpeedLine = GameObject.Find("Main Camera").transform.Find("speedLine").gameObject;


        Invoke("EnableTriggerDetection", 2f);
    }



    void EnableTriggerDetection()
    {
        GetComponent<BoxCollider>().enabled = true;
      
    }

    IEnumerator Activation(Collider other)
    {

            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isSlow = false;
            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isBoosted = true;
            if(SpeedLine!= null)
            {
            SpeedLine.SetActive(true);
            }
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            
        
   
        yield return new WaitForSeconds(3.0f);


       
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isBoosted = false;
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isSlow = false;
        if (SpeedLine != null)
        {
            SpeedLine.SetActive(false);
        }
        Destroy(gameObject);
    }




    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
                other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isBoosted = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Activation(other));
        }
    }

}
