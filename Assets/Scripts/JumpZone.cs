using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Activation(Collider other)
    {

     
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isJumpZone = true;

        if (other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().Grounded == true)
        {
            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isJumpZone = false;
        }

            yield return new WaitForSeconds(5.0f);

        
            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isJumpZone = false;
    }




    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isJumpZone = true;
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
