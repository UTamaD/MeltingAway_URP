using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pengSOund : MonoBehaviour
{
    public AudioClip[] _myAudio;
    // Start is called before the first frame update

    public float curTime = 0;
    // Update is called once per frame

    private void soundMaker()
    {
        
        int temp = 0;
        float rTemp = 0.0f;


      
            rTemp = Random.Range(0.0f,4.0f);

            if (rTemp < 1.0f)
            {
                temp = 0;
            }
            else if (rTemp < 2.0f)
            {
                temp = 1;
            }
            else if (rTemp < 3.0f)
            {
                temp = 2;
            }
            else 
            {
                temp = 3;
            }
         

        




       
        
            if (Random.Range(0.0f, 1.0f) > 0.7f)
            {

               
                    AudioSource myA = GetComponent<AudioSource>();
                    myA.clip = _myAudio[temp];
                    myA.Play();              
            }
            curTime = 0.0f;
    }
    void Update()
    {

        curTime += Time.deltaTime;
        if (curTime > 2.0f + Random.Range(-0.2f, 0.2f))
        {
            soundMaker();
        }
    }
}
