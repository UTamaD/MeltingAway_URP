using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowNBoost : MonoBehaviour
{

    public GameObject SpeedLine;
    public bool isBoost = true;
    // Start is called before the first frame update
    private void Awake()
    {

    }


    // Update is called once per frame

    IEnumerator Activation(Collider other)
    {

        if (isBoost)
        {
            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isSlow = false;
            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isBoosted = true;
            if (SpeedLine != null)
            {
                SpeedLine.SetActive(true);
            }
        }
        else
        {
            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isBoosted = false;
            other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isSlow = true;
        }
        yield return new WaitForSeconds(3.0f);


        if (SpeedLine != null)
        {
            SpeedLine.SetActive(false);
        }
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isBoosted = false;
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isSlow = false;
    }

    


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isBoost)
            {
                other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isBoosted = true;
            }
            else
            {
                other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isSlow = true;
            }
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
