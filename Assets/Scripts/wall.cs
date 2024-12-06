using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{

    public GameObject walls;


    private Rigidbody[] childRigidbodies;
    public void Start()
    {

        childRigidbodies = GetComponentsInChildren<Rigidbody>();

      


    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {

            //other.gameObject.GetComponentInParent<PlayerManager>().snowManLife -= 1.0f;
            other.GetComponent<PlayerManager>().LongVib();
            StartCoroutine(wallDestroyer());


        }

    }

    IEnumerator wallDestroyer()
    {
        foreach (Rigidbody childRigidbody in childRigidbodies)
        {

            childRigidbody.constraints = RigidbodyConstraints.None;

        }

        yield return new WaitForSeconds(30f);

        if(walls!= null)
        {
            Destroy(walls);
        }
        Destroy(gameObject);
      
        yield return null;
    }
}
