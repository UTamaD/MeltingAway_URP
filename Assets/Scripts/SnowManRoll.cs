using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManRoll : MonoBehaviour
{
    Transform _myTP;
    public PlayerManager _myPL;
    public float rollSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _myTP = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_myPL != null)
        {
            if(_myPL.size<0.167)
            {

            }
            else
            {
                _myTP.Rotate(rollSpeed, 0f, 0f);
            }
            
        }
        
    }
}
