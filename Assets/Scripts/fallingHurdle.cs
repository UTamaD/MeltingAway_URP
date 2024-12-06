using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingHurdle : MonoBehaviour
{

    private float curTime = 0;
    public float lifeTime = 10.0f;
   // public float speed = 5.0f;
    public float dirX = 0.0f;
    public float dirY = 180.0f;

    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.GetComponent<Transform>().Rotate(0, dirY, 0);

    }


    // Update is called once per frame

    private void FixedUpdate()
    {
        curTime += Time.deltaTime;


        if (curTime > lifeTime)
        {
            Destroy(gameObject);
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {

            if (other.tag == "Player")
            {
                //StartCoroutine(Vibrate());

                other.gameObject.GetComponentInParent<PlayerManager>().snowManLife -= 5.0f;
                other.GetComponent<PlayerManager>().callhitVib();
                // StartCoroutine(stay());
                Destroy(gameObject);


            }


        }

    }
}
