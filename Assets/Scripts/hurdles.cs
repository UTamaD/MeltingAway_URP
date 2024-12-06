using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class hurdles : MonoBehaviour
{


    public float curTime = 0;
    public float lifeTime = 40.0f;
    //public float speed = 5.0f;
    public float dirX = 0.0f;
    public float dirY = 180.0f;
    public Vector3 moveDir;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    private void Awake()
    {
        

        gameObject.GetComponent<Transform>().Rotate(0, dirY, 0);
        lifeTime = lifeTime  + Random.Range(-2.0f, 2.0f);
        moveDir = moveDir * Random.Range(1.0f, 1.1f);

    }

    // Update is called once per frame

    private void FixedUpdate()
    {

        curTime += Time.deltaTime;


        if (curTime > lifeTime)
        {
            Destroy(gameObject);
        }

       // gameObject.GetComponent<Transform>().Translate(moveDir);
    }



    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            //StartCoroutine(Vibrate());

            other.gameObject.GetComponentInParent<PlayerManager>().size -= 0.001f;
            other.GetComponent<PlayerManager>().callhitVib();
           // StartCoroutine(stay());
            Destroy(gameObject);


        }

    }

    void Start()
    {
       // StartCoroutine(Vibrate());
    }

}
