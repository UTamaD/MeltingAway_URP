using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdleGenerater : MonoBehaviour
{
    private float curTime = 0;
    public float cycle = 5.0f;
    public GameObject prefab;
    public Transform parent;
    public GameObject Goal;
    public bool isIce = false;
    // Start is called before the first frame update

    void Start()
    {
        parent = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        curTime += Time.deltaTime;

        if (curTime > cycle + Random.RandomRange(-1.0f,1.0f) )
        {
            GameObject myInstance = MonoBehaviour.Instantiate(prefab);
            

            if (isIce == true)
            {
                myInstance.name = "iceHurdle";
            }
            else
            {
                myInstance.name = "hurdle";
                myInstance.GetComponent<testMove>().destination = Goal.GetComponent<Transform>();
            }
            
            myInstance.transform.position = parent.position + new Vector3(0, Random.RandomRange(-1.0f,1.0f), 0);

            curTime = 0;
        }


    }
}

